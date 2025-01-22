import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';

import { useNotification } from '@components/snackbar/use-notification.ts';

import { Button } from '@components/button/button.tsx';
import { crearCapacitacion } from './api.ts';
import {
  BtnGroup,
  GroupToolbar,
} from '@components/toolbar-group/group-toolbar.tsx';
import { useNavigate } from 'react-router-dom';

const nameForm = 'cualquierCosa';
const Pagina = () => {
  const { success } = useNotification();
  const navigate = useNavigate();
  const guardar = async (values: any) => {
    await crearCapacitacion(values);
    success('Guardado correctamente');
    navigate(`/capacitaciones`);
  };
  return (
    <MainCard >
      <CapacitacionFormulario
        onSubmit={values => guardar(values as any)}
        nombreFormulario={nameForm}
      />

      <Row >
        <Col sx={{ mt: 2 }}>
          <GroupToolbar>
            <BtnGroup />
            <BtnGroup>
              <Button form={nameForm} type="submit" >
                Guardar
              </Button>
            </BtnGroup>
          </GroupToolbar>
        </Col>
      </Row>
    </MainCard>
  );
};
export default Pagina;
