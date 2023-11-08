import React from 'react';
import './NextEvent.css'

const NextEvent = ({title, decription, eventDate, idEvent}) => {
    function conectar(idEvent){
        alert(`Chamar recurso para conectar: ${idEvent}`)
    }

    return (
        <article className='event-card'>
            <h2 className='event-card__title'>{title}</h2>

            <p className='event-card__description'>{decription}</p>

            <p className='event-card__description'>{eventDate}</p>

            <a onClick={() => conectar(idEvent)} href="" className='event-card__connect-link'>Conectar</a>
        </article>
    );
};

export default NextEvent;