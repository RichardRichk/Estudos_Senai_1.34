import React from 'react';
import { Route, BrowserRouter, Routes } from "react-router-dom";
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';

import EventosPage from './pages/EventosPage/EventosPage';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import TipoEventos from './pages/TipoEventosPage/TipoEventosPage';

const routes = () => {
    return (
        <div>
            <BrowserRouter> 
                <Header/>
                <Routes>
                    <Route element={<HomePage />} path="/" exact />
                    <Route element={<LoginPage />} path="/login" />
                    <Route element={<TipoEventos />} path="/tipo-eventos" />
                    <Route element={<EventosPage />} path={"/eventos"} />
                </Routes>
                <Footer/>
            </BrowserRouter>
            
        </div>
    );
};

export default routes;