import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { useNotification } from '@components/snackbar/use-notification.ts';

const ConsultarCapacitacion = () => {
  const { id } = useParams<{ id: string }>();  // Obtener el 'id' de la URL
  const [capacitacion, setCapacitacion] = useState<any | null>(null);
  const { error } = useNotification();

  useEffect(() => {
    const fetchCapacitacion = async () => {
      try {
        const response = await fetch(`http://localhost:5090/api/v1/capacitacion/${id}`);
        if (!response.ok) {
          throw new Error('Capacitación no encontrada');
        }
        const data = await response.json();
        setCapacitacion(data);
      } catch (err) {
        error('Error al cargar la capacitación');
        console.error(err);
      }
    };

    fetchCapacitacion();
  }, [id, error]);

  if (!capacitacion) return <div>Cargando...</div>;

  return (
    <div>
      <h1>Detalles de la Capacitación</h1>
      <div>
        <strong>Código Capacitación:</strong> {capacitacion.codigoCapacitacion}
      </div>
      <div>
        <strong>Nombre Corto:</strong> {capacitacion.nombreCorto}
      </div>
      <div>
        <strong>Nombre Largo:</strong> {capacitacion.nombreLargo}
      </div>
      <div>
        <strong>Descripción:</strong> {capacitacion.descripcion}
      </div>
      <div>
        <strong>Ente Capacitador:</strong> {capacitacion.enteCapacitador}
      </div>
      <div>
        <strong>Modalidad:</strong> {capacitacion.modalidad}
      </div>
      <div>
        <strong>Lugar:</strong> {capacitacion.lugar}
      </div>
      <div>
        <strong>Horario:</strong> {capacitacion.horario}
      </div>
      <div>
        <strong>Fecha Inicio Registro:</strong> {capacitacion.fechaInicioRegistro}
      </div>
      <div>
        <strong>Fecha Fin Registro:</strong> {capacitacion.fechaFinRegistro}
      </div>
      <div>
        <strong>Estado:</strong> {capacitacion.estado}
      </div>
    </div>
  );
};

export default ConsultarCapacitacion;
