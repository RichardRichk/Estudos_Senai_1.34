import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";

const Rotas = () => {
    return(
        <div>
            <BrowserRouter>
                <Routes>
                    <Route element={<HomePage/>} path={"/"} exact />
                </Routes>
            </BrowserRouter>
        </div>
    );
};