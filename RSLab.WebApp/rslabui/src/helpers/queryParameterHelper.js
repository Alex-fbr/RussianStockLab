
export default class UrlQueryParameter {

    static GetParameterByName(name = '', url = '') {
        if (!url) url = window.location.href;

        name = name.replace(/[[\]]/g, '\\$&');
        var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url.toLowerCase());

        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, ' '));
    }
}
