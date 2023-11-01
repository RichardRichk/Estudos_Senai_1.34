import React, { useState } from 'react';
import Button from '../../componentes/Button/Button';
import Input from '../../componentes/Input/Input';
import Header from '../../componentes/Header/Header';
import Footer from '../../componentes/Footer/Footer';

const TestePage = () => {
    const [n1, setN1] = useState(); //number
    const [n2, setN2] = useState(); //number
    const [total, setTotal] = useState();

    function handleCalcular(e){
        e.preventDefault();
        setTotal(parseFloat(n1) + parseFloat(n2));
        console.log("Total");
    }


    return (
        <>
            <h1>Página de Poc's</h1>
            <h2>Calculadora</h2>

            <form action="" onSubmit={handleCalcular}>
                <Input type="number" placeholder="Primeiro número" name="n1" id="n1" value={n1} onChange= {(e) => {setN1(e.target.value)}}/>

                <br />

                <Input 
                type="number"
                placeholder="Segundo número" 
                name="n2" 
                id="n2" 
                value={n2} 
                onChange= {(e) => {setN2(e.target.value)}}
                />

                <br />

                <Button 
                textButton= "Calcular" 
                type="submit"
                // onClick = {() => handleCalcular(event)}            
                />

                <span>Resultado: <strong>{total}</strong> </span>
                <button onClick={handleCalcular}>calc</button>
            </form>

            <br />
            <span>N1: {n1}</span>
            <br />
            <span>N2: {n2}</span>

        </>
    );
};

export default TestePage;