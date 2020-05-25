import json
import utils
import speech_recognition
from clr import Models


DIGIT = 0
SINGLE_OPERATION = 1
BINARY_OPERATION = 2
ACTION = 3
SINGLE_OPERATIONS = {
    'factorial': Models.OperationType.FACTORIAL,
    'cs': Models.OperationType.CHANGE_SIGN,
    'position': Models.OperationType.POSITION,
    'inverse': Models.OperationType.INVERSE
}
BINARY_OPERATIONS = {
    'radical': Models.OperationType.RADICAL,
    'exponentiation': Models.OperationType.EXPONENTIATION,
    'division': Models.OperationType.DIVISION,
    'product': Models.OperationType.MULTIPLICATION,
    'subtraction': Models.OperationType.SUBTRACTION,
    'plus': Models.OperationType.SUM,
    'equal': Models.OperationType.EQUAL
}
ACTIONS = {
    'clear': Models.ActionType.CLEAR,
    'back': Models.ActionType.DELETE,
    'equal': Models.ActionType.POINT
}


class VoiceController:
    def record(self):
        r = speech_recognition.Recognizer()
        mic = speech_recognition.Microphone()
        with mic as source:
            r.adjust_for_ambient_noise(source)
            try:
                audio = r.listen(source, timeout=7)
            except speech_recognition.WaitTimeoutError:
                raise Exception('Timeout error.')
            try:
                transcript = r.recognize_google(audio)
            except:
                raise Exception('Could not connect to Google.')
            return transcript

    def execute(self, main_controller, transcript):
        words = transcript.lower().split()
        for word in words:
            (type, value) = self.interpret_word(word)
            if type == DIGIT:
                if main_controller.can_digit_button_press(value):
                    main_controller.digit_button_press(value)
            elif type == SINGLE_OPERATION:
                if main_controller.can_single_operation_button_press(value):
                    main_controller.single_operation_button_press(value)
            elif type == BINARY_OPERATION:
                if main_controller.can_binary_operation_button_press(value):
                    main_controller.binary_operation_button_press(value)
            elif type == ACTION:
                if main_controller.can_action_button_press(value):
                    main_controller.action_button_press(value)
            else:
                raise Exception(f'Couldn\'t interpret phrase: "{transcript}"')

    def interpret_word(self, word):
        data = dict()
        with open(utils.resource_path('Controllers/dictionary.json')) as json_file:
            data = json.load(json_file)
        if not word in data:
            return (None, None)
        entry = data[word]
        type = entry['type']
        value = entry['value']
        if type == SINGLE_OPERATION:
            value = SINGLE_OPERATIONS[value]
        elif type == BINARY_OPERATION:
            value = BINARY_OPERATIONS[value]
        elif type == ACTION:
            value = ACTIONS[value]
        return (type, value)