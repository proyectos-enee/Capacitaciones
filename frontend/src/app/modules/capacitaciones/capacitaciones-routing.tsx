import { Route, Routes } from 'react-router-dom';
import ConsultarCapacitacion from './consultar-capacitacion';
import CrearCapacitacion from './crear-capacitacion';

const CapacitacionesRouting = () => {
  return (
    <>
      <Routes>
        <Route path="" element={<ConsultarCapacitacion />} />
        <Route path="crear" element={<CrearCapacitacion />} />
      </Routes>
    </>
  );
};

export default CapacitacionesRouting;
