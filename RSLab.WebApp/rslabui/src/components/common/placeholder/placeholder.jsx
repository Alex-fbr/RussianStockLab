import React from 'react';
import cn from 'classnames';
import PropTypes from 'prop-types';

import st from './placeholder.module.scss';

const Placeholder = ({ text, icon, className }) => (
  <div className={cn(st.placeholder, className)}>
    {icon && (
    <div className={st.icon}>
      {icon}
    </div>
    )}
    {text}
  </div>
);

Placeholder.propTypes = {
  icon: PropTypes.oneOfType([PropTypes.string, PropTypes.node]),
  text: PropTypes.string,
  className: PropTypes.string,
};

Placeholder.defaultProps = {
  text: 'Placeholder',
  className: '',
};

export default Placeholder;
