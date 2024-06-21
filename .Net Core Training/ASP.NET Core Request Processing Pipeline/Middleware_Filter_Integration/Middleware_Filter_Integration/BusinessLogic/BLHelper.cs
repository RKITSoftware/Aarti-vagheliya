namespace Middleware_Filter_Integration.BusinessLogic
{
    /// <summary>
    /// This class provide helper methods implementation.
    /// </summary>
    public class BLHelper
    {
        #region Public Method

        /// <summary>
        /// Maps properties from a DTO to a POCO object.
        /// </summary>
        public Tpoco Map<Tdto, Tpoco>(Tdto source) where Tpoco : new()
        {
            var target = new Tpoco();

            // Iterate over properties of the source object
            foreach (var sourceProperty in typeof(Tdto).GetProperties())
            {
                // Find corresponding property in the target object
                var targetProperty = typeof(Tpoco).GetProperty(sourceProperty.Name);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    if (value != null)
                    {
                        // Check if the property types are compatible or assignable
                        if (targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            targetProperty.SetValue(target, value);
                        }
                        else
                        {
                            // Try converting the value to the target property type
                            var convertedValue = Convert.ChangeType(value, targetProperty.PropertyType);
                            targetProperty.SetValue(target, convertedValue);
                        }
                    }
                }
            }

            return target;
        }

        #endregion
    }
}
