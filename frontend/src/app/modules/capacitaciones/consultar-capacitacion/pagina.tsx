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
import EditIcon from '@mui/icons-material/Edit';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { Button } from '@components/button/button.tsx';
import { BtnGroup, GroupToolbar } from '@components/toolbar-group/group-toolbar.tsx';
import { useNavigate } from 'react-router';

const Pagina = () => {
  const navigate = useNavigate();
  const confirm = useConfirmDialog();
  const { success, error } = useNotification();
  const [search, setSearch] = useState<any>({});
  const [{ data }, refetch] = usePaginate<any>(httpApi, 'capacitaciones', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const eliminarCapacitacion = async (id: string) => {
    const result = await confirm({
      description: '¿Estás seguro de que deseas eliminar esta capacitación?',
    });
    if (result) {
      try {
        await httpApi.delete(`capacitaciones/${id}`);
        success('Capacitación eliminada correctamente');
        refetch(); // Refrescar la lista después de eliminar
      } catch (e) {
        error('Error al eliminar la capacitación');
      }
    }
  };

  const buscarCapacitacion = () => {
    setSearch({ nombreCorto: search.nombreCorto === undefined ? 'ejemplo' : undefined });
  };

  const actions: Array<ActionColumn> = [
    {
      color: 'info',
      icon: <VisibilityIcon />,
      label: 'Detalles',
      onClick: (rowData: any) => {
        navigate(`/capacitaciones/${rowData.id}`);
      },
    },
    {
      color: 'primary',
      icon: <EditIcon />,
      label: 'Editar',
      onClick: (rowData: any) => {
        navigate(`/capacitaciones/${rowData.id}/editar`);
      },
    },
    {
      color: 'error',
      icon: <DeleteIcon />,
      label: 'Eliminar',
      onClick: (rowData: any) => {
        eliminarCapacitacion(rowData.id);
      },
    },
  ];

  const columns: ColumnDef[] = [
    {
      headerName: 'Acciones',
      renderCell: generateActionColumn(actions),
    },
    {
      headerName: 'Código',
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

  const nuevo = () => {
    navigate('/capacitaciones/crear');
  };

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <GroupToolbar>
          <BtnGroup>
            <Button onClick={() => buscarCapacitacion()}>Buscar</Button>
            <Button onClick={() => nuevo()}>Nuevo</Button>


          </BtnGroup>
        </GroupToolbar>

        <PaginableGrid
          paginable={data as PaginateResult<any>}
          columnDefs={columns}
        />
      </MainCard>
    </>
  );
};

export default Pagina;
