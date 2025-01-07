import { useParams } from 'react-router';
import { useEffect, useState } from 'react';
import { useNotification } from '@components/snackbar/use-notification.ts';
import { httpApi } from '../../../http/http-api.ts';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { actualizarCapacitacion } from './api.ts'; // Función para actualizar la capacitación

const Pagina = () => {
  const { id } = useParams<{ id: string }>(); // Obtener el ID de la URL
  const { success, error } = useNotification();
  const [capacitacion, setCapacitacion] = useState<any>(null); // Datos de la capacitación
  const [loading, setLoading] = useState(true); // Estado de carga

  useEffect(() => {
    const cargarCapacitacion = async () => {
      try {
        if (!id) {
          error('No se proporcionó un ID válido.');
          return;
        }

        // Llama a la API para obtener los datos de la capacitación
        const response = await httpApi.get(`/capacitacion/${id}`);
        setCapacitacion(response.data ); // Guarda los datos en el estado
      } catch (err) {
        console.error('Error al cargar los datos:', err);
        error('No se pudo cargar la información de la capacitación.');
      } finally {
        setLoading(false); // Detiene el estado de carga
      }
    };

    cargarCapacitacion();
  }, [id]);

  const guardar = async (values: any) => {
    try {
      // Llama a la API para actualizar la capacitación
      await actualizarCapacitacion(id!, values);
      success('Capacitación actualizada correctamente');
    } catch (err) {
      console.error('Error al actualizar la capacitación:', err);
      error('No se pudo actualizar la capacitación.');
    }
  };

  if (loading) {
    return <p>Cargando datos de la capacitación...</p>;
  }

  if (!capacitacion) {
    return <p>No se encontraron datos para esta capacitación.</p>;
  }

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={guardar}
        nombreFormulario="editarCapacitacion"
        initialValues={{
          nombreCorto: capacitacion.nombreCorto || '',
          nombreLargo: capacitacion.nombreLargo || '',
          descripcion: capacitacion.descripcion || '',
          enteCapacitador: capacitacion.enteCapacitador || '',
          modalidad: {
            id: capacitacion.modalidad?.id || '',
            name: capacitacion.modalidad?.name || '',
          },
          lugar: capacitacion.lugar || '',
          horario: capacitacion.horario || '',
          fechaInicioRegistro: capacitacion.fechaInicioRegistro || '',
          fechaFinRegistro: capacitacion.fechaFinRegistro || '',
          estado: {
            id: capacitacion.estado?.id || '',
            name: capacitacion.estado?.name || '',
          },
        }}
      />
    </MainCard>
  );
};

export default Pagina;
