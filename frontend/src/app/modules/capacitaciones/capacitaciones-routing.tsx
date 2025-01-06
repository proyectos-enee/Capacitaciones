import { Route, Routes } from 'react-router-dom';
import ConsultarCapacitacion from './consultar-capacitacion';
import CrearCapacitacion from './crear-capacitacion';
//import EliminarCapacitacion from './eliminar-capacitacion';
import DetalleCapacitacion from './detalles-capacitacion';


const CapacitacionesRouting = () => {
  return (
    <>
      <Routes>
        <Route path="" element={<ConsultarCapacitacion />} />
        <Route path={'crear'} element={<CrearCapacitacion />} />
        <Route path={'Consultar'} element={<ConsultarCapacitacion />} />
        <Route path={'Detalle'} element={<DetalleCapacitacion />} />


      </Routes>
    </>
  );
};
export default CapacitacionesRouting;
