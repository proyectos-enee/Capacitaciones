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
import InfoIcon from '@mui/icons-material/Info';
import { Button } from '@components/button/button.tsx';
import { BtnGroup, GroupToolbar } from '@components/toolbar-group/group-toolbar.tsx';
import { useNavigate } from 'react-router';

const Pagina = () => {
  const navigate = useNavigate();
  const confirm = useConfirmDialog();
  const { success, error } = useNotification();
  const [search, setSearch] = useState<any>({});

  const [{ data }] = usePaginate<any>(httpApi, '', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const buscarCapacitaciones = () => {
    setSearch({
      codigoCapacitacion: search.codigoCapacitacion || '',
      nombreCorto: search.nombreCorto || '',
    });
  };

  const actions: Array<ActionColumn> = [
    {
      color: 'error',
      icon: <DeleteIcon />,
      onClick: (rowData: any) => {
        confirm({
          description: '¿Seguro que deseas eliminar esta capacitación?',
        }).then((result) => {
          if (result) {
            fetch(`http://localhost:5090/api/v1/capacitacion/${rowData.id}`, { method: 'DELETE' })
              .then((response) => {
                if (response.ok) {
                  success('Capacitación ha sido eliminada');
                } else {
                  error('Error al eliminar');
                }
              })
              .catch((err) => {
                console.error('Error en la petición:', err);
                error('Error en la eliminación de la capacitación');
              });
          }
        });
      },
    },
    {
      color: 'primary',
      icon: <EditIcon />,
      label: 'Editar',
      onClick: async (rowData: any) => {
        if (!rowData.id) {
          error('No se puede editar porque falta el ID de la capacitación.');
          return;
        }

        const confirmResult = await confirm({
          description: `¿Seguro que deseas editar la capacitación ${rowData.nombreCorto}?`,
        });

        if (confirmResult) {
          try {
            const response = await httpApi.get(`/api/v1/capacitaciones/${rowData.id}`);
            console.log('Datos de la capacitación para edición:', response);
            navigate(`/capacitaciones/actualizar`);
          } catch (err) {
            console.error('Error al obtener los datos de la capacitación:', err);
            error('No se pudo obtener la información de la capacitación para edición.');
          }
        }
      },
    },
    {
      color: 'secondary',
      icon: <InfoIcon />,
      label: 'Ver Detalles',
      onClick: (rowData: any) => {
        navigate(`/capacitaciones/${rowData.id}`);
      },
    },
  ];

  const columns: ColumnDef[] = [
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

  const nuevaCapacitacion = () => {
    navigate('/capacitaciones/crear');
  };

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <GroupToolbar>
          <BtnGroup>
            <Button onClick={buscarCapacitaciones}>Buscar</Button>
            <Button onClick={nuevaCapacitacion}>Crear Capacitacion</Button>
          </BtnGroup>
        </GroupToolbar>

        {/* Formulario de Búsqueda */}
        <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '20px' }}>
          <div style={{ display: 'flex', gap: '10px' }}>
            <input
              type="text"
              placeholder="Código de Capacitación"
              value={search.codigoCapacitacion}
              onChange={(e) => setSearch({ ...search, codigoCapacitacion: e.target.value })}
              style={{ padding: '5px', width: '200px' }}
            />
            <input
              type="text"
              placeholder="Nombre Corto"
              value={search.nombreCorto}
              onChange={(e) => setSearch({ ...search, nombreCorto: e.target.value })}
              style={{ padding: '5px', width: '200px' }}
            />
            <Button onClick={buscarCapacitaciones}>Buscar</Button>
          </div>
        </div>

        <PaginableGrid paginable={data as PaginateResult<any>} columnDefs={columns} />
      </MainCard>
    </>
  );
};

export default Pagina;
