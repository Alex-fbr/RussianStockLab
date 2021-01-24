import {
    NOTIFY,
    FETCH_RISLIST_SUCCESS,
    FETCH_RISLIST_REQUEST,
    SAVE_RIS_REQUEST,
    SAVE_RIS_SUCCESS,
    SAVE_RIS_FAILURE,
    UPDATE_RIS_REQUEST,
    UPDATE_RIS_SUCCESS,
    UPDATE_RIS_FAILURE,
    DELETE_RIS_REQUEST,
    DELETE_RIS_SUCCESS,
    DELETE_RIS_FAILURE,
    FETCH_RISLIST_FAILURE,
    FETCH_SELECTED_RIS_VALUES_REQUEST,
    FETCH_SELECTED_RIS_VALUES_SUCCESS,
    FETCH_SELECTED_RIS_VALUES_FAILURE
} from "../constants/actionsTypes";

import NotificationManager from '../components/notification/NotificationManager';
import { WARNING, ERROR, INFO, SUCCESS } from '../constants/notificationLevels';

const getAction = (type, payload) => {
    return {
        type: type,
        payload: payload
    };
};

const risListError = (error) => {
    return {
        type: FETCH_RISLIST_FAILURE,
        payload: error,
    };
};

const risRequested = (risId) => {
    return {
        type: FETCH_SELECTED_RIS_VALUES_REQUEST,
        payload: risId,
    };
};

const risLoaded = (data) => {
    return {
        type: FETCH_SELECTED_RIS_VALUES_SUCCESS,
        payload: data,
    };
};

const risError = (error) => {
    return {
        type: FETCH_SELECTED_RIS_VALUES_FAILURE,
        payload: error,
    };
};

// Загрузка значений справочника
const fetchRisValues = (risStoreService) => (risId) => (dispatch) => {
    dispatch(risRequested(risId));
    risStoreService
        .getRisValues(risId)
        .then(data => dispatch(risLoaded(data)))
        .catch(err => dispatch(risError(err)));
};

// Загрузка всех справочников
const fetchRisList = (risStoreService) => () => (dispatch) => {
    dispatch(getAction(FETCH_RISLIST_REQUEST, null));
    risStoreService
        .getRisList()
        .then((data) => dispatch(getAction(FETCH_RISLIST_SUCCESS, data)))
        .catch((err) => dispatch(risListError(err)));
};

// Сохранение справочника
const createRis = (risStoreService) => (newRis) => (dispatch) => {
    dispatch(getAction(SAVE_RIS_REQUEST, newRis));
    risStoreService
        .createRis(newRis)
        .then(risId => {
            dispatch(getAction(SAVE_RIS_SUCCESS, risId));
            console.log('Справочник сохранен. Вызываем fetchRisList');
            dispatch(fetchRisList(risStoreService)());
            NotificationManager.Success('Справочник сохранен');
        })
        .catch(error => {
            dispatch(getAction(SAVE_RIS_FAILURE, error.toString()));
            const message = error.message === "409" ? "Справочник c таким кодом уже существует" : "Серверная ошибка при создании справочника";
            NotificationManager.Error(message);
        });
};

// Обновление справочника
const updateRis = (risStoreService) => (updatedRis) => (dispatch) => {
    dispatch(getAction(UPDATE_RIS_REQUEST, updatedRis));
    risStoreService
        .updateRis(updatedRis)
        .then(data => {
            dispatch(getAction(UPDATE_RIS_SUCCESS, data));
            console.log('Справочник обновлен. Вызываем fetchRisList');
            dispatch(fetchRisList(risStoreService)());
            NotificationManager.Success('Справочник обновлен');
        })
        .catch(error => {
            dispatch(getAction(UPDATE_RIS_FAILURE, error.toString()));
            const message = error.message === "404"
                ? "Cправочника c таким Id не существует"
                : error.message === "409"
                    ? "Cправочник c таким кодом уже существует"
                    : "Серверная ошибка при обновлении элемента справочника";
            NotificationManager.Error(message);
        });
};

// Удаление справочника
const deleteRis = (risStoreService) => (risId) => (dispatch) => {
    dispatch(getAction(DELETE_RIS_REQUEST, risId));
    risStoreService
        .deleteRis(risId)
        .then(risId => {
            dispatch(getAction(DELETE_RIS_SUCCESS, risId));
            console.log('Справочник удален. Вызываем fetchRisList');
            dispatch(fetchRisList(risStoreService)());
            NotificationManager.Success('Справочник удален');
        })
        .catch(error => {
            dispatch(getAction(DELETE_RIS_FAILURE, error.toString()));
            const message = error.message === "404" ? "Справочник c таким Id не существует" : "Серверная ошибка при удалении справочника";
            NotificationManager.Error(message);
        });
};

const notify = (level, message) => (dispatch) => {
    switch (level) {
        case SUCCESS:
            NotificationManager.Success(message);
            break;

        case INFO:
            NotificationManager.Info(message);
            break;

        case WARNING:
            NotificationManager.Warning(message);
            break;

        case ERROR:
            NotificationManager.Error(message);
            break;
    }
    dispatch(getAction(NOTIFY, null));
}

export {
    notify,
    fetchRisList,
    fetchRisValues,
    createRis,
    updateRis,
    deleteRis,
};
