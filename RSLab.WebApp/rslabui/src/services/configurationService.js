import { CONFIG_ENDPOINT, URL_PATH, DEVELOPMENT_URL_PATH } from '../constants/api';

class ConfigurationService {
  apiUrl = undefined;
  routeBaseName = undefined;

  async getConfiguration() {
    console.log(`ConfigurationService.NODE_ENV = ${process.env.NODE_ENV}`);
    const endpoint = `${process.env.NODE_ENV === 'development' ? DEVELOPMENT_URL_PATH : URL_PATH}${CONFIG_ENDPOINT}`;
    console.log(`ConfigurationService.CONFIG_ENDPOINT = ${endpoint}`);

    const response = await fetch(endpoint);
    if (response.ok) {
      const result = await response.json();
      this.apiUrl = result.apiUrl;
      this.routeBaseName = result.routeBaseName;
      console.log(`ConfigurationService Success. apiUrl = ${result.apiUrl}`);
      console.log(`ConfigurationService Success. routeBaseName = ${result.routeBaseName}`);
    } else {
      console.log('ConfigurationService ERROR');
      this.apiUrl = '';
      this.routeBaseName = '';
    }
  }
}

export default new ConfigurationService();
