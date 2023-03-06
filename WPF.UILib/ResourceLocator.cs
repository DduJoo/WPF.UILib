using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.UILib
{
    public class ResourceLocator
    {
        public enum ThemeList { DarkColorScheme, LightColorScheme }


        public static Uri DarkColorScheme => new Uri("pack://application:,,,/WPF.UILib;component/ColorSchemes/Dark.xaml", UriKind.Absolute);
        public static Uri LightColorScheme => new Uri("pack://application:,,,/WPF.UILib;component/ColorSchemes/Light.xaml", UriKind.Absolute);


        public static void SetColorScheme(ResourceDictionary rootResourceDictionary, Uri colorSchemeResourceUri, Uri currentColorSchemeResourceUri = null)
        {
            Uri[] knownColorSchemes = currentColorSchemeResourceUri != null ? new[] { currentColorSchemeResourceUri } : new[] { LightColorScheme, DarkColorScheme };

            ResourceDictionary currentTheme = FindFirstContainedResourceDictionaryByUri(rootResourceDictionary, knownColorSchemes);
            
            rootResourceDictionary.MergedDictionaries.Add(new ResourceDictionary { Source = colorSchemeResourceUri });

            if (currentTheme != null)
            {
                if (!RemoveResourceDictionaryFromResourcesDeep(currentTheme, rootResourceDictionary))
                    throw new Exception("The currently active color scheme was found but could not be removed.");
            }
        }


        public static void SetColorScheme(ResourceDictionary rootResourceDictionary, string scheme, Uri currentColorSchemeResourceUri = null)
        {
            Uri[] knownColorSchemes = currentColorSchemeResourceUri != null ? new[] { currentColorSchemeResourceUri } : new[] { LightColorScheme, DarkColorScheme };

            ResourceDictionary currentTheme = FindFirstContainedResourceDictionaryByUri(rootResourceDictionary, knownColorSchemes);



            Uri? selectedScheme = null;

            switch (scheme)
            {
                case nameof(ThemeList.LightColorScheme):
                    selectedScheme = LightColorScheme;
                    break;
                case nameof(ThemeList.DarkColorScheme):
                    selectedScheme = DarkColorScheme;
                    break;
                default:
                    selectedScheme = LightColorScheme;
                    break;
            }
            
            rootResourceDictionary.MergedDictionaries.Add(new ResourceDictionary { Source = selectedScheme });

            if (currentTheme != null)
            {
                if (!RemoveResourceDictionaryFromResourcesDeep(currentTheme, rootResourceDictionary))
                    throw new Exception("The currently active color scheme was found but could not be removed.");
            }
        }



        private static ResourceDictionary FindFirstContainedResourceDictionaryByUri(ResourceDictionary resourceDictionary, Uri[] knownColorSchemes)
        {
            if (knownColorSchemes.Any(scheme => resourceDictionary.Source != null && resourceDictionary.Source.IsAbsoluteUri && resourceDictionary.Source.AbsoluteUri.Equals(scheme.AbsoluteUri)))
                return resourceDictionary;

            if (!resourceDictionary.MergedDictionaries.Any())
                return null;

            return resourceDictionary.MergedDictionaries.FirstOrDefault(d => FindFirstContainedResourceDictionaryByUri(d, knownColorSchemes) != null);
        }

        private static bool RemoveResourceDictionaryFromResourcesDeep(ResourceDictionary resourceDictionaryToRemove, ResourceDictionary rootResourceDictionary)
        {
            if (!rootResourceDictionary.MergedDictionaries.Any())
                return false;

            if (rootResourceDictionary.MergedDictionaries.Contains(resourceDictionaryToRemove))
            {
                rootResourceDictionary.MergedDictionaries.Remove(resourceDictionaryToRemove);
                return true;
            }

            return rootResourceDictionary.MergedDictionaries.Any(dict => RemoveResourceDictionaryFromResourcesDeep(resourceDictionaryToRemove, dict));
        }
    }
}
