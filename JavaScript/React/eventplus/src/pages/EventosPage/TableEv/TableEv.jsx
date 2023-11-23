import React from 'react';
import "./TableEv.css"
import editPen from '../../../assets/images/edit-pen.svg';
import trashDelete from '../../../assets/images/trash-delete.svg';
import { Tooltip } from 'react-tooltip';

const TableEv = ({ dados, fnDelete = null, fnUpdate = null }) => {
    return (
        <table className='table-data'>

            {/* cabecalho */}
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Evento</th>
                    <th className="table-data__head-title table-data__head-title--big">Descricao</th>
                    <th className="table-data__head-title table-data__head-title--big">Tipo Evento</th>
                    <th className="table-data__head-title table-data__head-title--big">Data</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>
            

            {/* Corpo */}
            <tbody>

                {dados.map((event) => {
                    return (
                        <tr className="table-data__head-row" key={event.idEvento}>
                            <td className="table-data__data table-data__data--big">
                                {event.nomeEvento}
                            </td>

                            <td className="table-data__data table-data__data--big">

                                <p 
                                    className='event-card__description'
                                    data-tooltip-id={event.idEvento}
                                    data-tooltip-content={event.descricao}
                                    data-tooltip-place="top"
                                >
                                    <Tooltip id={event.idEvento} className="custom-tooltip" />
                                    {event.descricao.substr(0, 15)}...
                                </p>

                            </td>

                            <td className="table-data__data table-data__data--big">
                                {event.tiposEvento.titulo}
                            </td>

                            <td className="table-data__data table-data__data--big">
                                {new Date(event.dataEvento).toLocaleDateString()}
                            </td>

                            <td className="table-data__data table-data__data--little">
                                <img 
                                className="table-data__icon" 
                                src={editPen} alt="" 
                                idEvento = {event.idEvento}
                                onClick={() => {
                                    fnUpdate(event.idEvento)
                                }}
                                />
                            </td>

                            <td 
                                className="table-data__data table-data__data--little">
                                <img 
                                    className="table-data__icon" 
                                    src={trashDelete} alt=""
                                    idevento = {event.idEvento} 
                                    onClick={() => {
                                        fnDelete(event.idEvento, event.nomeEvento)
                                    }}
                                />
                            </td>
                        </tr>
                    );
                })}

            </tbody>


        </table>
    );
};

export default TableEv;