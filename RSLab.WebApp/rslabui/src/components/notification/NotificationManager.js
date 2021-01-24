import { store } from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import { WARNING, ERROR, INFO, SUCCESS } from '../../constants/notificationLevels';

export default class NotificationManager {

    static CommonCommand(message = '', title = '', data = null) {

        if (window.CefSharp !== null
            && window.CefSharp !== undefined
            && window.CefSharp.PostMessage !== null
            && window.CefSharp.PostMessage !== undefined
        ) {
            window.CefSharp.PostMessage({
                Type: 'Alert',
                Data: data,
                Callback: null,
            });
        } else {
            let type = "info";
            let duration = 3000;
            switch (data?.Level) {
                case WARNING:
                    type = 'warning';
                    duration = 3000;
                    break;

                case ERROR:
                    type = 'danger';
                    duration = 5000;
                    break;

                case INFO:
                    type = 'info';
                    duration = 2000;
                    break;

                case SUCCESS:
                    type = 'success';
                    duration = 1500;
                    break;

                default:
                    type = 'info';
                    break;
            }

            store.addNotification({
                container: 'bottom-right',
                title: title,
                message: message,
                type: type,
                insert: "top",
                animationIn: ["animate__animated", "animate__fadeIn"],
                animationOut: ["animate__animated", "animate__fadeOut"],
                dismiss: {
                    duration: duration,
                    onScreen: true
                }
            });
        }
    }

    static Warning(message = '', title = 'Внимание') {
        NotificationManager.CommonCommand(message, title, { Level: WARNING, Message: message, Error: null });
    }

    static Error(message = '', title = 'Ошибка', error = null) {
        NotificationManager.CommonCommand(message, title, { Level: ERROR, Message: message, Error: error });
    }

    static Info(message = '', title = 'Информация') {
        NotificationManager.CommonCommand(message, title, { Level: INFO, Message: message, Error: null });
    }

    static Success(message = '', title = 'Успешно') {
        NotificationManager.CommonCommand(message, title, { Level: SUCCESS, Message: message, Error: null });
    }
}
