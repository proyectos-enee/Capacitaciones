import { useLocation, useNavigate, useParams } from 'react-router';
import { useEffect, useState } from 'react';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { useNotification } from '@components/snackbar/use-notification.ts';
import { actualizarCapacitacion } from './api.ts';
import { Button } from '@components/button/button.tsx';

const Pagina = () => {
  const { id } = useParams<{ id: string }>(); // Parámetro dinámico desde la URL
  const location = useLocation(); // Para manejar el estado pasado
  const navigate = useNavigate();
  const { success, error } = useNotification();
  const [capacitacion, setCapacitacion] = useState<any | null>(null);

  useEffect(() => {
    // Verificar si hay datos en el estado
    if (location.state && location.state.capacitacion) {
      setCapacitacion(location.state.capacitacion);
    } else if (id) {
      // Si no hay datos en el estado, se puede cargar desde la API
      const cargarCapacitacion = async () => {
        try {
          const response = await fetch(`http://localhost:5090/api/v1/capacitacion/${id}`, { method: 'ACTUALIZAR' });
          if (!response.ok) throw new Error('Error al cargar la capacitación.');
          const data = await response.json();
          setCapacitacion(data);
        } catch (err) {
          error('Error al cargar la capacitación.');
          navigate('/capacitaciones'); // Redirigir si no se puede cargar
        }
      };

      cargarCapacitacion();
    } else {
      error('No se encontró la capacitación.');
      navigate('/capacitaciones'); // Redirigir si no hay ID
    }
  }, [id, location.state, error, navigate]);

  const guardar = async (values: any) => {
    try {
      console.log(values);
      await actualizarCapacitacion(id!, values);
      success('Capacitación actualizada correctamente');
      navigate('/capacitaciones'); // Redirigir después de la actualización
    } catch (err) {
      error('Error al actualizar la capacitación.');
      console.error(err);
    }
  };

  if (!capacitacion) return <p>Cargando...</p>;

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={guardar}
        initialValues={capacitacion}
        nombreFormulario="actualizarCapacitacion"
      />
      <Button type="submit" form="actualizarCapacitacion">

        Actualizar
      </Button>
    </MainCard>
  );
};

export default Pagina;
