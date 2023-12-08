import React, { useContext, useEffect, useState } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";
import { UserContext } from "../../context/AuthContext";

import { Button, Input } from '../FormComponents/FormComponents'
import "./Modal.css";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = "Não informado. Não informado. Não informado.",
  newComentary,
  showHideModal = false,
  fnDelete = null,
  fnGet = null,
  fnPost = null,

}) => {

  const {userData} = useContext(UserContext)
  const [comentarioDesc, setComentarioDesc] = useState("");

  useEffect( () => {
    async function loadDados() {
      fnGet(userData.userId, userData.idEvento)
      console.log(userData);
    }
    loadDados();
  }, [comentaryText])

  return (
    <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={()=> showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={() => {fnDelete()}}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          additionalClass="comentary__entry"
          value={comentarioDesc}
          manipulationFunction={(e) => {
            setComentarioDesc(e.target.value)
          }}

        />
        {comentarioDesc}

        <Button
          textButton="Comentar"
          className="comentary__button"
          manipulationFunction={() => {
            fnPost(comentarioDesc.trim(), userData.userId, userData.idEvento);
          }}
        />
      </article>
    </div>
  );
};

export default Modal;
