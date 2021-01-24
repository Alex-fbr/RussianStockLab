import React, { Component } from "react";
import { compose, bindActionCreators } from "redux";
import { connect } from "react-redux";
import { withRisStoreService } from "../hoc";
import Spinner from "../spinner/spinner";
import ErrorIndicator from "../error-indicator/error-indicator";
import PropTypes from "prop-types";
import cn from "classnames";
import st from "./risList.module.scss";
import { notify, fetchRisList } from "../../actions";

const RisList = ({ data, fetchRisList, notify, className }) => {
  const refreshRisList = () => {
    console.log("Обновить список справочников");
    fetchRisList();
  };

  const onRisListItemHeaderNotify = (level, message) => {
    notify(level, message);
  };

  return (
    <div className={cn(st.offers, className)}>
      <div className={st.offersList}>Тут будет таблица</div>

      <div className={st.offerContainer}></div>
    </div>
  );
};

RisList.propTypes = {
  data: PropTypes.arrayOf(PropTypes.object),
  selectedRis: PropTypes.shape({
    id: PropTypes.string,
    comment: PropTypes.string,
    title: PropTypes.string,
  }),
  className: PropTypes.string,

  fetchRisValues: PropTypes.func,
  onSelectRis: PropTypes.func,
  createRis: PropTypes.func,
  updateRis: PropTypes.func,
  deleteRis: PropTypes.func,
  onSelectRisItem: PropTypes.func,
  createRisItem: PropTypes.func,
  updateRisItem: PropTypes.func,
  deleteRisItem: PropTypes.func,
  notify: PropTypes.func,
};

RisList.defaultProps = {
  className: "",
  selectedRis: null,
};

class RisListContainer extends Component {
  componentDidMount() {
    console.log("RisListContainer.componentDidMount()");
    this.props.fetchRisList();
  }

  render() {
    const { data, isLoading, error, fetchRisList, notify } = this.props;

    if (isLoading) {
      return (
        <div className={st.spin}>
          <Spinner />
        </div>
      );
    }

    if (error) {
      return <ErrorIndicator />;
    }

    return <RisList data={data} fetchRisList={fetchRisList} notify={notify} />;
  }
}

const mapStateToProps = ({
  risReducer: { risListState, risItemActionState, risItemValueActionState },
}) => {
  const { isLoading, error, selectedRis, data } = risListState;
  return {
    data,
    isLoading,
    error,
    selectedRis,
    risItemActionState,
    risItemValueActionState,
  };
};

const mapDispatchToProps = (dispatch, { risStoreService }) => {
  return bindActionCreators(
    {
      fetchRisList: fetchRisList(risStoreService),
      notify: (level, message) => notify(level, message),
    },
    dispatch
  );
};

export default compose(
  withRisStoreService(),
  connect(mapStateToProps, mapDispatchToProps)
)(RisListContainer);
