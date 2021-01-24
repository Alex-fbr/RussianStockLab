import {
    FETCH_RISLIST_SUCCESS,
    FETCH_RISLIST_REQUEST,
    FETCH_RISLIST_FAILURE,
    RISLIST_ROW_SELECT,
    RISLIST_ITEMS_ROW_SELECT,
    FETCH_SELECTED_RIS_VALUES_REQUEST,
    FETCH_SELECTED_RIS_VALUES_SUCCESS,
    FETCH_SELECTED_RIS_VALUES_FAILURE,
    SAVE_RIS_REQUEST,
    SAVE_RIS_SUCCESS,
    SAVE_RIS_FAILURE,
    UPDATE_RIS_REQUEST,
    UPDATE_RIS_SUCCESS,
    UPDATE_RIS_FAILURE,
    DELETE_RIS_REQUEST,
    DELETE_RIS_SUCCESS,
    DELETE_RIS_FAILURE,
    SAVE_RIS_ITEM_REQUEST,
    SAVE_RIS_ITEM_SUCCESS,
    SAVE_RIS_ITEM_FAILURE,
    UPDATE_RIS_ITEM_REQUEST,
    UPDATE_RIS_ITEM_SUCCESS,
    UPDATE_RIS_ITEM_FAILURE,
    DELETE_RIS_ITEM_REQUEST,
    DELETE_RIS_ITEM_SUCCESS,
    DELETE_RIS_ITEM_FAILURE,
} from "../constants/actionsTypes";

const initialState = {
    risListState: {
        data: [],
        isLoading: true,
        error: null,
        selectedRis: {
            data: null,
            selectedRisItem: null,
            selectedRisValues: [],
            isLoading: false,
            error: null,
        },
    },
    risItemActionState: {
        risData: null,
        inProgress: false,
        error: null,
        sucess: false
    },
    risItemValueActionState: {
        inProgress: false,
        error: null,
        sucess: false
    }
};

const risReducer = (state = initialState, action) => {
    switch (action.type) {

        case FETCH_RISLIST_REQUEST:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    isLoading: true,
                    selectedRis: {
                        data: null,
                        selectedRisItem: null,
                        selectedRisValues: [],
                        isLoading: false,
                        error: null,
                    },
                },
                risItemActionState: {
                    risData: null,
                    inProgress: false,
                    error: null,
                    sucess: false
                }
            };

        case FETCH_RISLIST_SUCCESS:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    isLoading: false,
                    data: action.payload,
                }
            };

        case FETCH_RISLIST_FAILURE:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    isLoading: false,
                    error: action.payload,
                }
            };

        case RISLIST_ROW_SELECT:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    selectedRis: {
                        ...state.risListState.selectedRis,
                        data: action.payload,
                        selectedRisItem: null,
                        selectedRisValues: [],
                    },
                },
                risItemActionState: {
                    risData: null,
                    inProgress: false,
                    error: null,
                    sucess: false
                },
                risItemValueActionState: {
                    inProgress: false,
                    error: null,
                    sucess: false
                },
            };

        case RISLIST_ITEMS_ROW_SELECT:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    selectedRis: {
                        ...state.risListState.selectedRis,
                        selectedRisItem: action.payload,
                    },
                },
                risItemValueActionState: {
                    inProgress: false,
                    error: null,
                    sucess: false
                }
            };

        case FETCH_SELECTED_RIS_VALUES_REQUEST:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    selectedRis: {
                        ...state.risListState.selectedRis,
                        isLoading: true,
                    },
                }
            };

        case FETCH_SELECTED_RIS_VALUES_SUCCESS:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    selectedRis: {
                        ...state.risListState.selectedRis,
                        isLoading: false,
                        selectedRisValues: action.payload,
                    },
                }
            };

        case FETCH_SELECTED_RIS_VALUES_FAILURE:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    selectedRis: {
                        ...state.risListState.selectedRis,
                        isLoading: false,
                        error: action.payload,
                    },
                }
            };

        case SAVE_RIS_REQUEST:
        case UPDATE_RIS_REQUEST:
        case DELETE_RIS_REQUEST:
            return {
                ...state,
                risItemActionState: {
                    ...state.risItemActionState,
                    inProgress: true,
                    success: false,
                    error: null,
                    risData: action.payload,
                }
            };

        case SAVE_RIS_SUCCESS:
        case UPDATE_RIS_SUCCESS:
        case DELETE_RIS_SUCCESS:
            return {
                ...state,
                risItemActionState: {
                    ...state.risItemActionState,
                    inProgress: false,
                    success: true,
                    error: null,
                    risData: {
                        Id: action.payload,
                    },
                }
            };

        case SAVE_RIS_FAILURE:
        case UPDATE_RIS_FAILURE:
        case DELETE_RIS_FAILURE:
            return {
                ...state,
                risItemActionState: {
                    ...state.risItemActionState,
                    inProgress: false,
                    success: false,
                    error: action.payload,
                    risData: null,
                }
            };

        case SAVE_RIS_ITEM_REQUEST:
        case UPDATE_RIS_ITEM_REQUEST:
        case DELETE_RIS_ITEM_REQUEST:
            return {
                ...state,
                risItemValueActionState: {
                    inProgress: true,
                    success: false,
                    error: null,
                }
            };

        case SAVE_RIS_ITEM_SUCCESS:
        case UPDATE_RIS_ITEM_SUCCESS:
        case DELETE_RIS_ITEM_SUCCESS:
            return {
                ...state,
                risListState: {
                    ...state.risListState,
                    selectedRis: {
                        ...state.risListState.selectedRis,
                        selectedRisItem: null,
                    },
                },
                risItemValueActionState: {
                    inProgress: false,
                    success: true,
                    error: null,
                }
            };

        case SAVE_RIS_ITEM_FAILURE:
        case UPDATE_RIS_ITEM_FAILURE:
        case DELETE_RIS_ITEM_FAILURE:
            return {
                ...state,
                risItemValueActionState: {
                    inProgress: false,
                    success: false,
                    error: action.payload,
                }
            };

        default:
            return state;
    }
};

export default risReducer;
