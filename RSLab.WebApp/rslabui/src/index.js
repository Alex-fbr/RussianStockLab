import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter as Router } from 'react-router-dom';
import App from './components/app';
import ErrorBoundry from './components/error-boundry';
import RisStoreService from './services/risStoreService';
import { RisStoreServiceProvider } from './components/ris-store-service-context';
import ConfigurationService from './services/configurationService';
import store from './store';

async function initApp() {
  await ConfigurationService.getConfiguration();
  const risStoreService = new RisStoreService();

  ReactDOM.render(
    <Provider store={store}>
      <ErrorBoundry>
        <RisStoreServiceProvider value={risStoreService}>
          <Router basename={ConfigurationService.routeBaseName}>
            <App />
          </Router>
        </RisStoreServiceProvider>
      </ErrorBoundry>
    </Provider>,
    document.getElementById('root')
  );
}

initApp().then(() => {
  console.log('Инициализация приложения');
});

