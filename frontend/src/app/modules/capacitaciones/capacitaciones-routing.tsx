import { Route, Routes } from 'react-router-dom';
import ConsultarCapacitacion from './consultar-capacitacion';
import CrearCapacitacion from './crear-capacitacion';
import DetalleCapacitacion from './detalles-capacitacion';
import ActualizarCapacitacion from './actualizar-capacitacion';
import VisualizarCapacitacion from './visualizar-capacitacion';
import RegistroCapacitacion from './registro-capacitacion';
const CapacitacionesRouting = () => {
  return (
    <Routes>
      <Route path="" element={<ConsultarCapacitacion />} />
      <Route path="crear" element={<CrearCapacitacion />} />
      <Route path="actualizar/:id" element={<ActualizarCapacitacion />} />
      <Route path="consultar" element={<ConsultarCapacitacion />} />
      <Route path="detalle" element={<DetalleCapacitacion />} />
      <Route path="visualizar" element={<VisualizarCapacitacion />} />
      <Route path="registro" element={<RegistroCapacitacion />} />
    </Routes>
  );
};

export default CapacitacionesRouting;
