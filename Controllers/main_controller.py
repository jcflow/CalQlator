import threading
from Controllers.constants import *
from clr import Models
from Controllers.voice_controller import VoiceController


class MainController:
    def __init__(self, window):
        self.calculator_manager = Models.DisplayableCalculatorController()
        self.voice_controller = VoiceController()
        self.window = window

        # Setup digits.
        for (name, value) in DIGITS:
            getattr(self.window, name).pressed.connect(
                lambda v=value: self.digit_button_press(v))

        # Setup single operations.
        for (name, operation_type) in SINGLE_OPERATIONS:
            getattr(self.window, name).pressed.connect(
                lambda ot=operation_type: self.single_operation_button_press(ot))

        # Setup binary operations.
        for (name, operation_type) in BINARY_OPERATIONS:
            getattr(self.window, name).pressed.connect(
                lambda ot=operation_type: self.binary_operation_button_press(ot))

        # Setup actions.
        for (suffix, action_type) in ACTIONS:
            getattr(self.window, '%s' % suffix).pressed.connect(
                lambda at=action_type: self.action_button_press(at))

        # Setup numeric system.
        for (name, numeric_system_type) in NUMERIC_SYSTEMS:
            getattr(self.window, name).pressed.connect(
                lambda nst=numeric_system_type: self.numeric_system_press(nst))

        # Setup recorder.
        self.window.pushButton_record.pressed.connect(self.record_press)

        self.refresh_ui()

    def record_press(self):
        try:
            value = []
            thread = threading.Thread(target=lambda: value.append(self.voice_controller.record()))
            thread.start()
            thread.join()
            if len(value) == 0:
                raise Exception('Audio could not be recognized.')
            self.voice_controller.execute(self, value[0])
        except Exception as error:
            self.window.show_error_message(error)
            self.reset()

    def refresh_ui(self):
        self.refresh_numeric_system()
        self.refresh_buttons()
        self.refresh_display()

    def refresh_numeric_system(self):
        for (name, numeric_system_type) in NUMERIC_SYSTEMS:
            getattr(self.window, name).setChecked(self.calculator_manager.NumericSystem == numeric_system_type)

    def refresh_buttons(self):
        # Update digits.
        for (name, value) in DIGITS:
            getattr(self.window, name).setDisabled(not self.can_digit_button_press(value))

        # Update single operations.
        for (name, operation_type) in SINGLE_OPERATIONS:
            getattr(self.window, name).setDisabled(not self.can_single_operation_button_press(operation_type))

        # Update binary operations.
        for (name, operation_type) in BINARY_OPERATIONS:
            getattr(self.window, name).setDisabled(not self.can_binary_operation_button_press(operation_type))

        # Update actions.
        for (name, action_type) in ACTIONS:
            getattr(self.window, name).setDisabled(not self.can_action_button_press(action_type))

    def refresh_display(self):
        display = self.calculator_manager.Display
        self.window.lcd.display(display)

    def numeric_system_press(self, numeric_system_type):
        self.calculator_manager.NumericSystem = numeric_system_type
        self.refresh_ui()

    def digit_button_press(self, value):
        try:
            self.calculator_manager.AppendDigit(value)
            self.refresh_ui()
        except Exception as error:
            self.window.show_error_message(error)
            self.reset()

    def single_operation_button_press(self, operation_type):
        try:
            self.calculator_manager.ExecuteSingularOperation(operation_type)
            self.refresh_ui()
        except Exception as error:
            self.window.show_error_message(error)
            self.reset()

    def binary_operation_button_press(self, operation_type):
        try:
            self.calculator_manager.ExecuteBinaryOperation(operation_type)
            self.refresh_ui()
        except Exception as error:
            self.window.show_error_message(error)
            self.reset()

    def action_button_press(self, action_type):
        try:
            self.calculator_manager.ExecuteAction(action_type)
            self.refresh_ui()
        except Exception as error:
            self.window.show_error_message(error)
            self.reset()

    def can_action_button_press(self, action_type):
        return self.calculator_manager.CanActionBeExecuted()

    def can_binary_operation_button_press(self, operation_type):
        return self.calculator_manager.CanOperationBeExecuted(operation_type)

    def can_digit_button_press(self, value):
        return self.calculator_manager.IsValidDigit(value)

    def can_single_operation_button_press(self, operation_type):
        return self.calculator_manager.CanOperationBeExecuted(operation_type)

    def reset(self):
        self.calculator_manager = Models.DisplayableCalculatorController()
        self.refresh_ui()
