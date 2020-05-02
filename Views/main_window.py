import traceback
from PyQt5.QtWidgets import *
from PyQt5 import uic


class MainWindow(QMainWindow):
    def __init__(self, *args, **kwargs):
        super(MainWindow, self).__init__(*args, **kwargs)
        uic.loadUi('Views/main_window.ui', self)

    def show_error_message(self, error):
        self.setDisabled(True)
        msg = QMessageBox()
        msg.setIcon(QMessageBox.Critical)

        msg.setText("Last operation threw an error!")
        msg.setInformativeText(error.Message if hasattr(error, 'Message') else error)
        msg.setWindowTitle("CalQlator")
        msg.setDetailedText("The details are as follows: \n%s" %
                            error.get_StackTrace() if hasattr(error, 'get_StackTrace') else traceback.format_exc())
        msg.setStandardButtons(QMessageBox.Ok)
        msg.exec_()
        self.setDisabled(False)