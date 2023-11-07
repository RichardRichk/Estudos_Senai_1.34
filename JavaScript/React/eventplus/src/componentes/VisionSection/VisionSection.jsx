import React from 'react';
import './VisionSection.css';
import Title from '../Title/Title.jsx'


const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>
                <Title
                    titleText={"Visao"}
                    color='White'
                    className='vision__title'
                />
                <p className='vision__text'>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Obcaecati omnis repudiandae architecto saepe quisquam aliquid inventore, dolor rerum velit exercitationem, asperiores praesentium, quae deserunt necessitatibus fuga sint ad. Molestias, quisquam!</p>
            </div>
        </section>
    );
};

export default VisionSection;