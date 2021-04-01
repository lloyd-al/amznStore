import React, { useState, useEffect } from 'react';
import Slide from '@material-ui/core/Slide';

import CarouselSlide from './CarouselSlide';
import Arrow from './Arrow';
import { SLIDE_INFO } from './BannerList';


import "./Banners-style.css";

function Banners() {
    const [index, setIndex] = useState(0);
    const content = SLIDE_INFO[index];
    const numSlides = SLIDE_INFO.length;

    const [slideIn, setSlideIn] = useState(true);
    const [slideDirection, setSlideDirection] = useState('down');


    const onArrowClick = (direction) => {
        const increment = direction === 'left' ? -1 : 1;
        const newIndex = (index + increment + numSlides) % numSlides;
        setIndex(newIndex);

        const oppDirection = direction === 'left' ? 'right' : 'left';
        setSlideDirection(direction);
        setSlideIn(false);

        setTimeout(() => {
            setIndex(newIndex);
            setSlideDirection(oppDirection);
            setSlideIn(true);
        }, 400);
    };

    useEffect(() => {
        const handleKeyDown = (e) => {
            if (e.keyCode === 39) {
                onArrowClick('right');
            }
            if (e.keyCode === 37) {
                onArrowClick('left');
            }
        };

        window.addEventListener('keydown', handleKeyDown);

        return () => {
            window.removeEventListener('keydown', handleKeyDown);
        };
    });

    return (
        <div className="banner">
            <Slide in={slideIn} direction={slideDirection} >
                <div>
                    <CarouselSlide content={content} />
                </div>
            </Slide>

            <div className="arrow_left">
                <Arrow direction='left' clickFunction={() => onArrowClick('left')} />
            </div>
            <div className="arrow_right">
                <Arrow direction='right' clickFunction={() => onArrowClick('right')} />
            </div>
        </div>
    );
}
export default Banners;
