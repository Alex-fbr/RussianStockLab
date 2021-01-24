import React from 'react';
import cn from 'classnames';
import PropTypes from 'prop-types';
import Button from '../../../uikit/button/button';

import st from './acceptButtons.module.scss';

const AcceptButtons = ({
    position,
    acceptBtnText,
    cancelBtnText,
    acceptBtnDisabled,
    cancelBtnDisabled,
    onAcceptClick,
    onCancelClick,
    className,
}) => {
    const positionClass = position === 'right' ? st.acceptButtonsRight : st.acceptButtonsLeft;

    return (
        <div className={cn(st.acceptButtons, positionClass, className)}>
            <Button
                onClick={onAcceptClick}
                text={acceptBtnText}
                disabled={acceptBtnDisabled}
                filled
            />
            <Button
                onClick={onCancelClick}
                text={cancelBtnText}
                disabled={cancelBtnDisabled}
            />
        </div>
    )
};

AcceptButtons.propTypes = {
    acceptBtnText: PropTypes.string,
    cancelBtnText: PropTypes.string,
    position: PropTypes.string,
    className: PropTypes.string,
    acceptBtnDisabled: PropTypes.bool,
    cancelBtnDisabled: PropTypes.bool,

    onAcceptClick: PropTypes.func,
    onCancelClick: PropTypes.func,
};

AcceptButtons.defaultProps = {
    position: 'left',
    acceptBtnText: 'Сохранить',
    cancelBtnText: 'Отмена',
    className: '',
    acceptBtnDisabled: false,
    cancelBtnDisabled: false,

    onAcceptClick: () => { },
    onCancelClick: () => { },
};

export default AcceptButtons;
