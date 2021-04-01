import React from 'react';
import { FaChevronLeft, FaChevronRight } from 'react-icons/fa';

function Arrow(props) {
    const { direction, clickFunction, style } = props;
    const icon = direction === 'left' ? <FaChevronLeft size={70} /> : <FaChevronRight size={70} />;

    return (<div style={ style } onClick={clickFunction}>{icon}</div>);
}

export default Arrow;