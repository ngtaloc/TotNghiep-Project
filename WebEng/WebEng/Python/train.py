"""An example of how to use your own dataset to train a classifier that recognizes people.
"""
# MIT License
#
# Copyright (c) 2016 David Sandberg
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
# copies of the Software, and to permit persons to whom the Software is
# furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in all
# copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
# SOFTWARE.
# Modify by nkloi@hcmut.edu.vn
# 3/2020

from __future__ import absolute_import
from __future__ import division
from __future__ import print_function

import shutil

import tensorflow as tf
import numpy as np
import argparse
import os
import sys
import math
import pickle
from sklearn.svm import SVC
import facenet.face_contrib
from facenet.facenet import *
from align.align_mtcnn import  *
import time
import pyodbc


class DBConnet():

    @staticmethod
    def getConnet():
        try:
            conn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};'
                                  # Loc
                                  # 'Server=DESKTOP-4UPPHLQ\SQLEXPRESS;' 'Database=TotNghiep;'
                                  #'Server=(LocalDB)\MSSQLLocalDB;' 'Database=TotNghiep;'

                                  # Hau
                                  # 'Server=DESKTOP-LM0C49R\SQLEXPRESS;' 'Database=DOAN_CHUYENNGANH;'

                                  # QUOC
                                   'Server=DESKTOP-TD9R29S;' 'Database=DoAnTotNghiep;'
                                  'Trusted_Connection=Yes'
                                  )
            return conn
        except Exception as e:
            print(e)



def Train(data_dir,
          model,
          classifier_filename,
          use_split_dataset=None,
          batch_size=1000,
          image_size=160,
          seed=123,
          min_nrof_images_per_class=20,
          nrof_train_images_per_class=10):
    """
    Train with your dataset
    :param data_dir:
    :param model:
    :param classifier_filename:
    :param use_split_dataset:
    :param batch_size:
    :param image_size:
    :param seed:
    :param min_nrof_images_per_class:
    :param nrof_train_images_per_class:
    :return:
    """
    with tf.Graph().as_default():
        with tf.Session() as sess:
            np.random.seed(seed=seed)
            if use_split_dataset:
                dataset_tmp = get_dataset(data_dir)
                train_set, test_set = split_dataset(dataset_tmp, min_nrof_images_per_class,
                                                    nrof_train_images_per_class)
                dataset = train_set
            else:
                dataset = get_dataset(data_dir)

            # Check that there are at least one training image per class
            for cls in dataset:
                assert (len(cls.image_paths) > 0, 'There must be at least one image for each class in the dataset')

            paths, labels = get_image_paths_and_labels(dataset)

            #print('Number of classes: %d' % len(dataset))
            #print('Number of images: %d' % len(paths))

            # Load the model
            #print('Loading feature extraction model')
            load_model(model)

            # Get input and output tensors
            images_placeholder = tf.get_default_graph().get_tensor_by_name("input:0")
            embeddings = tf.get_default_graph().get_tensor_by_name("embeddings:0")
            phase_train_placeholder = tf.get_default_graph().get_tensor_by_name("phase_train:0")
            embedding_size = embeddings.get_shape()[1]

            # Run forward pass to calculate embeddings
            #print('Calculating features for images')
            nrof_images = len(paths)
            nrof_batches_per_epoch = int(math.ceil(1.0 * nrof_images / batch_size))
            emb_array = np.zeros((nrof_images, embedding_size))
            for i in range(nrof_batches_per_epoch):
                start_index = i * batch_size
                end_index = min((i + 1) * batch_size, nrof_images)
                paths_batch = paths[start_index:end_index]
                images = load_data(paths_batch, False, False, image_size)
                feed_dict = {images_placeholder: images, phase_train_placeholder: False}
                emb_array[start_index:end_index, :] = sess.run(embeddings, feed_dict=feed_dict)

            classifier_filename_exp = os.path.expanduser(classifier_filename)

            # Train classifier
            #print('Training classifier')
            model = SVC(kernel='linear', probability=True)
            model.fit(emb_array, labels)

            # Create a list of class names
            class_names = [cls.name.replace('_', ' ') for cls in dataset]

            # Saving classifier model
            with open(classifier_filename_exp, 'wb') as outfile:
                pickle.dump((model, class_names), outfile)
            #print('Saved classifier model to file "%s"' % classifier_filename_exp)


def split_dataset(dataset, min_nrof_images_per_class, nrof_train_images_per_class):
    train_set = []
    test_set = []
    for cls in dataset:
        paths = cls.image_paths
        # Remove classes with less than min_nrof_images_per_class
        if len(paths) >= min_nrof_images_per_class:
            np.random.shuffle(paths)
            train_set.append(ImageClass(cls.name, paths[:nrof_train_images_per_class]))
            test_set.append(ImageClass(cls.name, paths[nrof_train_images_per_class:]))
    return train_set, test_set

faceCascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')

def add_overlays(frame, faces, frame_rate, colors, confidence=0.2):
    if faces is not None:
        for idx, face in enumerate(faces):
            face_bb = face.bounding_box.astype(int)
            cv2.rectangle(frame, (face_bb[0], face_bb[1]), (face_bb[2], face_bb[3]), colors[idx], 2)
            if face.name and face.prob:
                if face.prob > confidence:
                    class_name = face.name
                else:
                    class_name = 'Unknow'
                    # class_name = face.name
                cv2.putText(frame, class_name, (face_bb[0], face_bb[3] + 20), cv2.FONT_HERSHEY_SIMPLEX, 0.6,
                            colors[idx], thickness=2, lineType=2)
                cv2.putText(frame, '{:.02f}'.format(face.prob * 100), (face_bb[0], face_bb[3] + 40),
                            cv2.FONT_HERSHEY_SIMPLEX, 0.6, colors[idx], thickness=1, lineType=2)

    cv2.putText(frame, str(frame_rate) + " fps", (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0),
                thickness=2, lineType=2)
def cutface2(idtk):
    frame_interval = 3  # Number of frames after which to run face detection
    fps_display_interval = 5  # seconds
    frame_rate = 0
    frame_count = 0
    video_capture = cv2.VideoCapture(0)
    face_recognition = facenet.face_contrib.Detection()
    start_time = time.time()
    colors = np.random.uniform(0, 255, size=(1, 3))
    sampleNum=0
    while True:
        # Capture frame-by-frame
        ret, frame = video_capture.read()

        if (frame_count % frame_interval) == 0:
            faces = face_recognition.find_faces(frame)
            for i in range(len(colors), len(faces)):
                colors = np.append(colors, np.random.uniform(150, 255, size=(1, 3)), axis=0)
            # Check our current fps
            end_time = time.time()
            if (end_time - start_time) > fps_display_interval:
                frame_rate = int(frame_count / (end_time - start_time))
                start_time = time.time()
                frame_count = 0
            if (not os.path.exists('your_face/'+idtk)):
                os.makedirs('your_face/'+idtk )
            cv2.imwrite('your_face/'+idtk+'/' + str(sampleNum) + '.jpg', frame)
            sampleNum += 1

        if sampleNum > 200:
            break
        add_overlays(frame, faces, frame_rate, colors)

        frame_count += 1
        assert isinstance(frame, object)
        cv2.imshow('Video', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

if __name__ == '__main__':

    conn = DBConnet.getConnet()
    query = "SELECT * FROM TaiKhoan"
    cursor = conn.execute(query)
    idtk = None
    for row in cursor:  # kiểm tra trong data đã thêm chưa
       if row[7] == 0:
            idtk = row[0]

    if idtk != None:
        try:
            # start cam và quét mặt
            cutface2(str(idtk))
            align_mtcnn('your_face', 'face_align')
            Train('face_align/', 'models/20180402-114759.pb', 'models/your_model.pkl')
            try:
                shutil.rmtree('your_face')

            except:{}
            q = "UPDATE TaiKhoan SET face=1 WHERE id= " + str(idtk) + ""
            conn.execute(q)
        except Exception as e:
            print(e)
	#print(idtk)
    conn.commit()
    conn.close()

