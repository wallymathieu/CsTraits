using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    //https://bixuanzju.github.io/files/traits.pdf

    public interface IVersion { string Version { get; } };
    public interface IEditor
    {
        string OnKey(string key);
        string DoCut();
        string Help();
    }
    public interface IVersionTrait:IVersion
    {
        string IVersion.Version => "None";
    }

    public interface IEditorTrait : IEditor, IVersion
    {
        string IEditor.OnKey(string key) => "Pressing "+key;
        string IEditor.DoCut() => this.OnKey("C-x")+ " for cutting text";
        string IEditor.Help() => "Version: " + this.Version + " Basic usage...";
    }
    #if false
/*
trait spell [self : OnKey] => {
on_key(key : String) = "Process " ++ key ++ " on spell editor";
check = self.on_key "C-c" ++ " for spell checking"
};
 */
    public interface ISpellTrait : IOnKey
    {
        string IOnKey.OnKey(string key) => "Process " + key + " on spell editor";
        string Check() => this.OnKey("C-c") + " for spell checking";
    }
    #endif
    
}
