import sys
import clr
import utils
from PyQt5.QtWidgets import *
from Views.main_window import MainWindow
sys.path.append(utils.resource_path('build'))
clr.AddReference('Models')
from Controllers.main_controller import MainController

if __name__ == '__main__':
    app = QApplication([])
    app.setApplicationName('CalQlator')
    window = MainWindow()
    controller = MainController(window)
    window.show()
    app.exec_()
