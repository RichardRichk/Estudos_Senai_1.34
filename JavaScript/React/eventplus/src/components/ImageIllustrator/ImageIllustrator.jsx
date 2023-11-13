import React from 'react';
import './ImageIllustrator.css';

const ImageIllustrator = ({altText, imageRender, additionalClass}) => {

    return (
        <figure className='illustrator-box'>
            <img 
            src={imageRender} 
            alt={altText} 
            className={`illustrator-box__image ${additionalClass}`}
            />
        </figure>
    );
};

export default ImageIllustrator;