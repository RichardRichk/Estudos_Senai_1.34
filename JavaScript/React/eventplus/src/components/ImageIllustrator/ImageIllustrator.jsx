import React from 'react';
import './ImageIllustrator.css';
import imgDefault from '../../assets/images/default-image.jpeg'

const ImageIllustrator = ({altText, imageRender = imgDefault, additionalClass}) => {

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