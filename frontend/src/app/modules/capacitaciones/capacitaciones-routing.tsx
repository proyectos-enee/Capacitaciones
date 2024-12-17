import { Route, Routes } from 'react-router-dom';
import ConsultarCapacitacion from './consultar-capacitacion';
import CrearCapacitacion from './crear-capacitacion';
import EliminarCapacitacion from './eliminar-capacitacion';


const CapacitacionesRouting = () => {
  return (
    <>
      <Routes>
        <Route path="" element={<ConsultarCapacitacion />} />
        <Route path={'crear'} element={<CrearCapacitacion />} />
        <Route path={'eliminar'} element={<EliminarCapacitacion />} />

      </Routes>
    </>
  );
};
export default CapacitacionesRouting;
