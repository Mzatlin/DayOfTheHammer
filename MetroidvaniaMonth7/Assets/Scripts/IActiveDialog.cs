using System;
internal interface IActiveDialog
{
    event Action OnDialogStart;
    bool IsActive { get; }
}