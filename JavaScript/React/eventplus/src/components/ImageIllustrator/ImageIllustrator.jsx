import React from 'react';
import './ImageIllustrator.css';
import tipoEventoImage from '../../assets/images/tipo-evento.svg';
import eventoImage from '../../assets/images/eventoImage';

const ImageIllustrator = ({altText, imageName, additionalClass}) => {

    let imageResource

    switch (imageName) {
        case 'tipo-evento':
            imageResource = tipoEventoImage
            break;

        case 'evento':
            break;   
        default:
            break;
    }

    return (
        <figure className='illustrator-box'>
            <img 
            src={imageResource} 
            alt={altText} 
            className={`illustrator-box__image ${additionalClass}`}
            />
        </figure>
    );
};

export default ImageIllustrator;