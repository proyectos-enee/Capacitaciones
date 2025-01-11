import { ControlForm } from '../control-form';
import { Controller, useFormContext } from 'react-hook-form';
import {
  FormControl,
  FormHelperText,
  InputLabel,
  MenuItem,
  Select,
  Skeleton,
} from '@mui/material';
import { useExtractedStatus } from '@components/form/use-extracted-status.tsx';

interface Props extends ControlForm {
  labelField?: string;
  valueField?: string;
  items: any[];
  disabled?: boolean;
  hidden?: boolean;
  whenChange?: (event: any) => void;
  disableVariant?: boolean;
}

const ComboBox = ({
                    label,
                    whenChange,
                    name,
                    placeholder,
                    readOnly,
                    items,
                    valueField,
                    labelField,
                    disabled = false,
                    hidden = false,
                    disableVariant,
                  }: Props) => {
  const { control, watch } = useFormContext();
  const status = useExtractedStatus(name);
  const isLoading = watch('$isloading');
  const newLabel = labelField ?? 'name';
  const newDataField = valueField ?? 'id';
  const variant = disableVariant ? undefined : 'filled';

  return (
    <>
      <FormControl
        component="fieldset"
        fullWidth
        variant={variant}
        disabled={disabled}
      >
        <InputLabel id={name}>{label}</InputLabel>
        <Controller
          name={name}
          control={control}
          render={({ field }) => (
            <>
              {isLoading ? (
                <Skeleton variant="rounded" height={51} />
              ) : (
                <>
                  <Select
                    hidden={hidden}
                    {...field}
                    label={label}
                    name={name}
                    id={name}
                    aria-disabled={disabled}
                    value={field?.value?.[newDataField] || ''} // Manejo seguro de valor
                    onChange={value => {
                      const item = items.find(
                        x => x[newDataField] === value.target.value,
                      ) || null; // Asegura un valor por defecto
                      field.onChange(item); // Actualiza el valor en el hook form
                      if (whenChange) {
                        whenChange(item); // Llama al callback si está definido
                      }
                    }}
                    placeholder={placeholder}
                    disabled={readOnly}
                    error={status?.hasError}
                    renderValue={() =>
                      field.value ? `${field.value[newLabel]}` : ''
                    } // Manejo seguro de renderValue
                  >
                    {items.length === 0 && (
                      <MenuItem value="">Ninguno</MenuItem>
                    )}
                    {items.map(data => {
                      return (
                        <MenuItem
                          key={data[newDataField]}
                          value={data[newDataField]}
                        >
                          {data[newLabel]}
                        </MenuItem>
                      );
                    })}
                  </Select>
                  <FormHelperText error={status?.hasError}>
                    {status?.errorMsg}
                  </FormHelperText>
                </>
              )}
            </>
          )}
        />
      </FormControl>
    </>
  );
};

export default ComboBox;
