import React, { useContext, useEffect, useState } from "react";

import MainContent from "../../components/Main/MainContent";
import Title from "../../components/Titulo/Titulo";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal.jsx";
import api, { eventsResource, myEventosResource } from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";


const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);


  
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("0"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {

    async function loadEvents(){

      // setEventos([]);
  
      if (tipoEvento === "1") {//Todos os eventos
  
        try {
          //Listar os eventos (Evento)
          const retorno = await api.get(eventsResource);
          setEventos(retorno.data);
        } catch (error) {
          console.log("Erro na api");
          console.log(error);
        }
        
      } else if (tipoEvento === "2"){

        //Listar neys evebtis(PresencasEventos)
        //Retorna um formato diferente de array

        try {

          const retornoEventos = await api.get(`${myEventosResource}/${userData.userId}`);

          const arrEventos = []; //Array vazio

          retornoEventos.data.forEach(e => {

            arrEventos.push(e.evento);

          });

          setEventos(arrEventos);
          console.log(retornoEventos.data);

        } catch (error) {
          
          console.log("Erro na api");
          console.log(error);

        }
      } else {
        setEventos ([]);
      }
    }
    
    loadEvents();
  }, [tipoEvento]); //userData.userId


  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const verificaPresenca = (arrayAllEvents, eventsUser) => {
    for (let x = 0; x < arrayAllEvents.length; x++) { //Para cada evento cadastrado
      for (let i = 0; i < eventsUser.length; i++) { //procurar a correspondencia
        
        arrayAllEvents [x].situacao = true;
        break; //paro de procurar para o evento principal atual
        
      }
    }
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }
  return (
    <>

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
