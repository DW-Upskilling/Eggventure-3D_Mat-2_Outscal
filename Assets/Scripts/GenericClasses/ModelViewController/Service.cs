using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.GenericClasses.ModelViewController
{
    public abstract class Service<T>: Singleton<Service<T>> where T : Service<T>{}
}
