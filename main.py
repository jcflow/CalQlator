import pathlib
import os
import sys
import clr
from PyQt5.QtWidgets import *
from Views.main_window import MainWindow
current_path = pathlib.Path().absolute()
assembly_path = os.path.join(current_path, "build")
sys.path.append(assembly_path)
clr.AddReference('Models')
from Controllers.main_controller import MainController

if __name__ == '__main__':
    app = QApplication([])
    app.setApplicationName("CalQlator")
    window = MainWindow()
    controller = MainController(window)
    window.show()
    app.exec_()
