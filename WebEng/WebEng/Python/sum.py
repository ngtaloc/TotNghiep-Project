
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


def cutface2():
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
            if (not os.path.exists('your_face/'+'1')):
                os.makedirs('your_face/'+'1' )
            cv2.imwrite('your_face/'+'1'+'/' + str(sampleNum) + '.jpg', frame)
            sampleNum += 1

        if sampleNum > 20:
            break
        #add_overlays(frame, faces, frame_rate, colors)

        frame_count += 1
        assert isinstance(frame, object)
        cv2.imshow('Video', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

cutface2()