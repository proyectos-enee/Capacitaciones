import { useEffect, useState } from 'react';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';
import { Button } from '@components/button/button.tsx';
import { useNotification } from '@components/snackbar/use-notification.ts';
import { useParams, useNavigate } from 'react-router-dom';
import { httpApi } from '../../../http/http-api.ts';
import { actualizarCapacitacion } from './api.ts';
import { Capacitacion } from '../common/capacitacion.model.ts';

const nameForm = 'actualizarCapacitacion';

const Pagina = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const { success, error } = useNotification();
  const [initialValues, setInitialValues] = useState<Capacitacion | null>(null);

  useEffect(() => {
    // Cargar los datos de la capacitación seleccionada
    if (id) {
      httpApi
        .get<Capacitacion>(` /api/v1/capacitacion/${id}`) // Especifica el tipo de respuesta
        .then((response) => setInitialValues(response))
        .catch(() => error('Error al cargar los datos de la capacitación'));
    }
  }, [id, error]);

  const guardar = async (values: any) => {
    try {
      console.log('ACTUALIZAR', values);

      // Llamada al backend para actualizar la capacitación
      await actualizarCapacitacion(id!, {
        ...values,
        modalidad: values.modalidad.id,
        estado: values.estado.id,
      });

      success('Capacitación actualizada correctamente');
      navigate('/capacitaciones'); // Redirige a la lista de capacitaciones
    } catch (e: any) {
      if (e.response?.status === 400) {
        error(e.response.data?.Error || 'Error al actualizar la capacitación.');
      } else {
        error('Ocurrió un error inesperado. Por favor, intente de nuevo más tarde.');
      }
    }
  };

  if (!initialValues) return <div>Cargando...</div>;

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={(values) => guardar(values)}
        nombreFormulario={nameForm}
        initialValues={initialValues} // Pasar valores iniciales al formulario
      />
      <Row>
        <Col>
          <Button form={nameForm} type="submit">
            Guardar Cambios
          </Button>
        </Col>
      </Row>
    </MainCard>
  );
};

export default Pagina;
