import React from 'react';
import { Spin } from 'antd';
import { LoadingOutlined } from '@ant-design/icons';
import 'antd/dist/antd.css';

const antIcon = <LoadingOutlined style={{ fontSize: 36 }} spin />;

const Spinner = (spinning = true) => {
    return <Spin tip="Загрузка..." indicator={antIcon} spinning={spinning} />;
};

export default Spinner;
