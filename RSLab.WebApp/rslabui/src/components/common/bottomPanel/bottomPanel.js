import React from 'react';
import cn from 'classnames';
import PropTypes from 'prop-types';

import st from './bottomPanel.module.scss';

const BottomPanel = ({ children, className }) => {
    return (
        <div className={cn(st.bottomPanel, className)}>
            {children}
        </div>
    );
};

BottomPanel.propTypes = {
    children: PropTypes.node,
    className: PropTypes.string,
};

BottomPanel.defaultProps = {};

export default BottomPanel;