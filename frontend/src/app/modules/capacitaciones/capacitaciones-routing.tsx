import { Route, Routes } from 'react-router-dom';
import ConsultarCapacitacion from './consultar-capacitacion';
import CrearCapacitacion from './crear-capacitacion';
//import EliminarCapacitacion from './eliminar-capacitacion';
import DetalleCapacitacion from './detalles-capacitacion';
import ActualizarCapacitacion from './actualizar-capacitacion';



const CapacitacionesRouting = () => {
  return (
    <>
      <Routes>
        <Route path="" element={<ConsultarCapacitacion />} />
        <Route path={'crear'} element={<CrearCapacitacion />} />
        <Route path={'actualizar'} element={<ActualizarCapacitacion />} />
        <Route path={'consultar'} element={<ConsultarCapacitacion />} />
        <Route path={'detalle'} element={<DetalleCapacitacion />} />


      </Routes>
    </>
  );
};
export default CapacitacionesRouting;
