import { useConfirmDialog } from '@components/dialog/confirm-dialog';
import { useNotification } from '@components/snackbar/use-notification.ts';

import { httpApi } from '../../../http/http-api.ts';
import { usePaginate } from '@common/hooks/use-paginate.ts';
import { useState } from 'react';
import { PaginableGrid } from '@components/grid/paginable-grid.tsx';
import { PaginateResult } from '@common/hooks/models/paginate-result.ts';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { ColumnDef } from '@components/grid/models/column-def.tsx';
import {
  ActionColumn,
  generateActionColumn,
} from '@components/grid/components/action-column.tsx';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button } from '@components/button/button.tsx';
import { BtnGroup, GroupToolbar } from '@components/toolbar-group/group-toolbar.tsx';
import { useNavigate } from 'react-router';
const Pagina = () => {
  const navigate = useNavigate();
  const confirm = useConfirmDialog();
  const { success, error } = useNotification();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [search, setSearch] = useState<any>({});
  const [{ data }] = usePaginate<any>(httpApi, '', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const open = async () => {
    const result = await confirm({
      description:
        'Por favor, ayudame a enteder si estas seguro de que la accion que realizaras es correcta ',
    });
    if (result) {
      alert('Confirmado');
    }
  };

  const toast = () => {
    success('I love snacks.');
    success(' snacks.');
    error('Error snacks.');
  };

  const buscarNombre = () => {
    setSearch({ codigoCapacitacion: search.codigoCapacitacion === undefined ? 'jose' : undefined });
  };

  const actions: Array<ActionColumn> = [
    {
      color: 'error',
      icon: <DeleteIcon />,
      onClick: (rowData: any) => {
        alert(rowData.codigoCapacitacion);
      },
    },
    {
      color: 'info',
      icon: <DeleteIcon />,
      onClick: (rowData: any) => {
        alert(rowData.codigoCapacitacion);
      },
    },
    {
      color: 'warning',
      label: 'Warning',
      icon: <></>,
      onClick: (rowData: any) => {
        alert(rowData.codigoCapacitacion);
      },
    },
  ];
  const colums: ColumnDef[] = [
    {
      headerName: 'Acciones',
      renderCell: generateActionColumn(actions),
    },
    {
      headerName: 'Codigo Capacitacion',
      field: 'codigoCapacitacion',
    },
    {
      headerName: 'Nombre Corto',
      field: 'nombreCorto',
    },
    {
      headerName: 'Estado',
      field: 'estado',
    },
  ];
  const actualizar = ()=> {
    navigate('/capacitaciones/actualizar');
  }
  const eliminar = ()=> {
    navigate('/capacitaciones/eliminar');
  }
  const nuevo = ()=>{
    navigate('/capacitaciones/crear');
  }
  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <GroupToolbar>
          <BtnGroup>
            <Button onClick={() => open()}>Open</Button>
            <Button onClick={() => toast()}>Toast</Button>
            <Button onClick={() => eliminar()}>Eliminar</Button>
            <Button onClick={() => actualizar()}>Actualizar</Button>
            <Button onClick={() => buscarNombre()}>buscar</Button>
            <Button onClick={() => nuevo()}>Nuevo</Button>
          </BtnGroup>
        </GroupToolbar>


        <PaginableGrid
          paginable={data as PaginateResult<any>}
          columnDefs={colums}
        />
      </MainCard>
    </>
  );
};
export default Pagina;
