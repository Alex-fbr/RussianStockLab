import React from "react";
import { Route, Switch } from "react-router-dom";
import RisPage from "../pages/risPage";
import ReactNotification from 'react-notifications-component';
import 'react-notifications-component/dist/theme.css';
import st from './app.module.scss';

const App = () => {
  return (
    <div className={st.app}>
      <ReactNotification />
      <Switch>
        <Route path="/" component={RisPage} exact />
      </Switch>
    </div>
  );
};

export default App;
