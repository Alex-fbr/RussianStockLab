import ConfigurationService from './configurationService';
import UrlQueryParameter from '../helpers/queryParameterHelper';
import { USER_NAME_PARAMETER, SYSTEM_NAME_PARAMETER } from '../constants/urlQueryParameterNames';

export default class RisStoreService {
    constructor() {
        this._apiBase = ConfigurationService.apiUrl;
    }

    addUrlQueryParameter = (fullUrl) => {
        const userName = UrlQueryParameter.GetParameterByName(USER_NAME_PARAMETER);
        const systemName = UrlQueryParameter.GetParameterByName(SYSTEM_NAME_PARAMETER);
        let secondChar = '?';

        if (userName !== null && userName !== undefined) {
            fullUrl = `${fullUrl}?${USER_NAME_PARAMETER}=${userName}`;
            secondChar = '&';
        }

        if (systemName !== null && systemName !== undefined) {
            fullUrl = `${fullUrl}${secondChar}${SYSTEM_NAME_PARAMETER}=${systemName.toUpperCase()}`;
        }

        console.log(`Запрос по адресу = ${fullUrl}`);
        return fullUrl;
    }

    getResource = async (url) => {
        let fullUrl = this.addUrlQueryParameter(`${this._apiBase}${url}`);
        const response = await fetch(fullUrl);
        if (!response.ok) {
            console.log(`Could not get '${this._apiBase}${url}', received ${response.status}`);
            throw new Error(response.status);
        }
        return await response.json();
    };

    putResource = async (url, model) => {
        let fullUrl = this.addUrlQueryParameter(`${this._apiBase}${url}`);
        const response = await fetch(fullUrl, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(model),
        });

        if (!response.ok) {
            console.log(`Could not put '${this._apiBase}${url}', received ${response.status}`);
            throw new Error(response.status);
        }

        return await response.json();
    }

    postResource = async (url, model) => {
        let fullUrl = this.addUrlQueryParameter(`${this._apiBase}${url}`);
        const response = await fetch(fullUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(model),
        });

        if (!response.ok) {
            console.log(`Could not post '${this._apiBase}${url}', received ${response.status}`);
            throw new Error(response.status);
        }

        return await response.json();
    }

    deleteResource = async (url, id) => {
        let fullUrl = this.addUrlQueryParameter(`${this._apiBase}${url}${id}`);
        console.log(`Запрос по адресу = ${fullUrl}`);

        const response = await fetch(fullUrl, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
        });

        if (!response.ok) {
            console.log(`Could not delete '${this._apiBase}${url}', received ${response.status}`);
            throw new Error(response.status);
        }

        return await response.json();
    }

    getRisList = async () => {
        return await this.getResource('/RisEditor/dictionary');
    };

    createRis = async (newRis) => {
        return await this.postResource(`/RisEditor/dictionary/`, newRis);
    };

    updateRis = async (updatedRis) => {
        return await this.putResource(`/RisEditor/dictionary/`, updatedRis);
    };

    deleteRis = async (oldRisId) => {
        return await this.deleteResource(`/RisEditor/dictionary/`, oldRisId);
    };
}
