import React, { useContext, useState, useEffect } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg"
import { Input, Button } from "../../components/FormComponents/FormComponents";
import loginImage from "../../assets/images/login.svg";
import Notification from '../../components/Notification/Notification'
import api, { loginResource } from "../../Services/Service";
import { useNavigate } from "react-router-dom";

import "./LoginPage.css"
import { UserContext, userDecodeToken } from "../../context/AuthContext";

const LoginPage = () => {
    const [notifyUser, setNotifyerUser] = useState();
    const [user, setUser] = useState({ email: "adm@adm.com", senha: "" });
    //importando os dados globais do usuario
    const {userData, setUserData} = useContext(UserContext); 
    const navigate = useNavigate();


    useEffect(() => {
        if(userData.nome) navigate("/")
      }, [userData]);


    async function handleSubmit(e) {
        e.preventDefault();
        if (user.email.trim().length >=3 && user.senha.trim().length >=3) {
            try {
                const promise = await api.post(loginResource, {
                    email: user.email,
                    senha: user.senha
                });

                console.log("DADOS DO USUARIO");
                console.log(promise.data);

                const userFullToken = userDecodeToken(promise.data.token);
                //Guarda o token globalmente
                setUserData(userFullToken);
                localStorage.setItem("token", JSON.stringify(userFullToken));

                //Envia o usuario para a pagina home
                navigate("/"); 

                setNotifyerUser({
                    titleNote: "Sucesso",
                    textNote: `sucesso`,
                    imgIcon: "success",
                    imgAlt: "Imagem de ilustracai de sucessi.moca segurando um balao com simbolo de confirmacao ok",
                    showMessage: true
                });

            } catch (error) {
                setNotifyerUser({
                    titleNote: "Erro",
                    textNote: `Verifique os dados ou sua conexao com a internet`,
                    imgIcon: "warning",
                    imgAlt:
                    "Imagem de ilustracai de erro, Warning!",
                    showMessage: true,
                });
            }
            
        } else{
            setNotifyerUser({
                titleNote: "Erro",
                textNote: `Verifique os dados ou sua conexao com a internet`,
                imgIcon: "warning",
                imgAlt:
                "Imagem de ilustracai de erro, Warning!",
                showMessage: true,
            });
        }
    }



    return (
        <>
        <Notification {...notifyUser} setNotifyUser={setNotifyerUser} />
        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>

                    <ImageIllustrator
                        imageRender={loginImage}
                        imageName="login"
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        additionalClass={"login-illustrator"}
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form 
                    className="frm-login__formbox"
                    onSubmit={handleSubmit}
                    >
                        <Input
                            additionalClass="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            onChange={(e) => { }}
                            placeholder="Username"
                            manipulationFunction={(e) => {setUser({...user, email: e.target.value.trim()})}}
                        />
                        <Input
                            additionalClass="frm-login__entry"
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            onChange={(e) => { }}
                            placeholder="********"
                            manipulationFunction={(e) => {setUser({...user, senha: e.target.value.trim()})}}
                        />

                        <Button
                            textButton="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            additionalClass="frm-login__button"
                        />

                        <a href="" className="frm-login__link">
                            Esqueceu a senha?
                        </a>
                    </form>
                </div>
            </div>
        </div>
        </>
    );
};

export default LoginPage;
