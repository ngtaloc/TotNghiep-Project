import pyodbc

from datetime import time

import cv2
import numpy as np
from PyQt5 import QtCore
from PyQt5.QtGui import QImage, QPixmap


class DBConnet():

    @staticmethod
    def getConnet():
        try:
            conn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};'
                                  # Loc
                                  # 'Server=DESKTOP-4UPPHLQ\SQLEXPRESS;' 'Database=TotNghiep;'
                                  'Server=(LocalDB)\MSSQLLocalDB;' 'Database=TotNghiep;'

                                  # Hau
                                  # 'Server=DESKTOP-LM0C49R\SQLEXPRESS;' 'Database=DOAN_CHUYENNGANH;'

                                  # QUOC
                                  # 'Server=DESKTOP-TD9R29S;' 'Database=chuyen_nganh;'
                                  'Trusted_Connection=Yes'
                                  )
            return conn
        except Exception as e:
            print(e)


face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + "haarcascade_frontalface_default.xml")


def loadcam1():
    vid = cv2.VideoCapture(0)
    while (vid.isOpened()):
        img, frame = vid.read()
        # frame = imutils.resize(frame, height=600, width=800)
        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        faces = face_cascade.detectMultiScale(
            gray,
            scaleFactor=1.12,
            minNeighbors=5,
            minSize=(30, 30)
            # flags=cv2.CV_HAAR_SCALE_IMAGE
        )
        for (x, y, w, h) in faces:
            # cv2.rectangle(frame, (x, y), (x + w, y + h), (10, 228, 220), 2)
            cv2.line(frame, (int((x + x + w) / 2), y), (int((x + x + w) / 2), y + h), (10, 228, 220), 2)
            cv2.line(frame, (x, int((y + y + h) / 2)), (x + w, int((y + y + h) / 2)), (10, 228, 220), 2)

        # self.displayImage1(frame, 1)
        cv2.imshow('', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
    vid.release()
    cv2.destroyAllWindows()


if __name__ == '__main__':

    conn = DBConnet.getConnet()
    query = "SELECT * FROM TaiKhoan"
    cursor = conn.execute(query)
    isRecordExits = 0
    idtk = None
    for row in cursor:  # kiểm tra trong data đã thêm chưa
        if row[4] == 1:
            idtk = row[0]

        isRecordExits = 1

    if idtk != None:
        try:
            # start cam và quét mặt
            loadcam1()
            print(idtk)
        except Exception as e:
            print(e)

    conn.commit()
    conn.close()