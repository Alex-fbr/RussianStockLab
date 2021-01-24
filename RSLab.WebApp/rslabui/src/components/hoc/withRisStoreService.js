import React from "react";
import { RisStoreServiceConsumer } from "../ris-store-service-context";

const withRisStoreService = () => (Wrapped) => {
  return (props) => {
    return (
      <RisStoreServiceConsumer>
        {(risStoreService) => {
          return <Wrapped {...props} risStoreService={risStoreService} />;
        }}
      </RisStoreServiceConsumer>
    );
  };
};

export default withRisStoreService;
