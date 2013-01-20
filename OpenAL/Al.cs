﻿#region --- OpenTK.OpenAL License ---
/* AlFunctions.cs
 * C header: \OpenAL 1.1 SDK\include\Al.h
 * Spec: http://www.openal.org/openal_webstf/specs/OpenAL11Specification.pdf
 * Copyright (c) 2008 Christoph Brandtner and Stefanos Apostolopoulos
 * See license.txt for license details
 * http://www.OpenTK.net */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Security;

using Ibasa.Numerics.Geometry;

/* Type Mapping
// 8-bit boolean 
typedef char ALboolean;
 * bool
// character 
typedef char ALchar;
 * byte
// signed 8-bit 2's complement integer 
typedef char ALbyte;
 * byte

// unsigned 8-bit integer 
typedef unsigned char ALubyte;
 * byte

// signed 16-bit 2's complement integer 
typedef short ALshort;
 * short

// unsigned 16-bit integer 
typedef unsigned short ALushort;
 * ushort

// unsigned 32-bit integer 
typedef unsigned int ALuint;
 * uint
 
// signed 32-bit 2's complement integer 
typedef int ALint;
 * int
// non-negative 32-bit binary integer size 
typedef int ALsizei;
 * int
// enumerated 32-bit value
typedef int ALenum;
 * int

// 32-bit IEEE754 floating-point 
typedef float ALfloat;
 * float

// 64-bit IEEE754 floating-point 
typedef double ALdouble;
 * double

// void type (for opaque pointers only) 
typedef void ALvoid;
 * void
*/

namespace Ibasa.OpenAL
{
    /// <summary>
    /// Provides access to the OpenAL 1.1 flat API.
    /// </summary>
    internal static class Al
    {
        #region Renderer State management

        /// <summary>This function enables a feature of the OpenAL driver. There are no capabilities defined in OpenAL 1.1 to be used with this function, but it may be used by an extension.</summary>
        /// <param name="capability">The name of a capability to enable.</param>
        [DllImport("openal32.dll", EntryPoint = "alEnable", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Enable(AlCapability capability);
        //AL_API void AL_APIENTRY alEnable( ALenum capability );

        /// <summary>This function disables a feature of the OpenAL driver.</summary>
        /// <param name="capability">The name of a capability to disable.</param>
        [DllImport("openal32.dll", EntryPoint = "alDisable", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Disable(AlCapability capability);
        // AL_API void AL_APIENTRY alDisable( ALenum capability ); 

        /// <summary>This function returns a boolean indicating if a specific feature is enabled in the OpenAL driver.</summary>
        /// <param name="capability">The name of a capability to enable.</param>
        /// <returns>True if enabled, False if disabled.</returns>
        [DllImport("openal32.dll", EntryPoint = "alIsEnabled", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern bool IsEnabled(AlCapability capability);
        // AL_API ALboolean AL_APIENTRY alIsEnabled( ALenum capability ); 

        #endregion Renderer State management

        #region State retrieval

        [DllImport("openal32.dll", EntryPoint = "alGetString", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity()]
        private static extern IntPtr GetStringPrivate(AlGetString param); // accepts the enums AlError, AlContextString
        // AL_API const ALchar* AL_APIENTRY alGetString( ALenum param );

        /// <summary>This function retrieves an OpenAL string property.</summary>
        /// <param name="param">The property to be returned: Vendor, Version, Renderer and Extensions</param>
        /// <returns>Returns a pointer to a null-terminated string.</returns>
        public static string Get(AlGetString param)
        {
            return Marshal.PtrToStringAnsi(GetStringPrivate(param));
        }

        /// <summary>This function retrieves an OpenAL string property.</summary>
        /// <param name="param">The human-readable errorstring to be returned.</param>
        /// <returns>Returns a pointer to a null-terminated string.</returns>
        public static string GetErrorString(AlError param)
        {
            return Marshal.PtrToStringAnsi(GetStringPrivate((AlGetString)param));
        }

        /* no functions return more than 1 result ..
        // AL_API void AL_APIENTRY alGetBooleanv( ALenum param, ALboolean* buffer );
        // AL_API void AL_APIENTRY alGetIntegerv( ALenum param, ALint* buffer );
        // AL_API void AL_APIENTRY alGetFloatv( ALenum param, ALfloat* buffer );
        // AL_API void AL_APIENTRY alGetDoublev( ALenum param, ALdouble* buffer );
        */

        /* disabled due to no token using it
        /// <summary>This function returns a boolean OpenAL state.</summary>
        /// <param name="param">the state to be queried: AL_DOPPLER_FACTOR, AL_SPEED_OF_SOUND, AL_DISTANCE_MODEL</param>
        /// <returns>The boolean state described by param will be returned.</returns>
        [DllImport( "openal32.dll", EntryPoint = "alGetBoolean", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl ), SuppressUnmanagedCodeSecurity( )]
        public static extern bool Get( ALGetBoolean param );
        // AL_API ALboolean AL_APIENTRY alGetBoolean( ALenum param );
        */

        /// <summary>This function returns an integer OpenAL state.</summary>
        /// <param name="param">the state to be queried: DistanceModel.</param>
        /// <returns>The integer state described by param will be returned.</returns>
        [DllImport("openal32.dll", EntryPoint = "alGetInteger", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern int Get(AlGetInteger param);
        // AL_API ALint AL_APIENTRY alGetInteger( ALenum param );

        /// <summary>This function returns a floating-point OpenAL state.</summary>
        /// <param name="param">the state to be queried: DopplerFactor, SpeedOfSound.</param>
        /// <returns>The floating-point state described by param will be returned.</returns>
        [DllImport("openal32.dll", EntryPoint = "alGetFloat", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern float Get(AlGetFloat param);
        // AL_API ALfloat AL_APIENTRY alGetFloat( ALenum param );

        /* disabled due to no token using it
        /// <summary>This function returns a double-precision floating-point OpenAL state.</summary>
        /// <param name="param">the state to be queried: AL_DOPPLER_FACTOR, AL_SPEED_OF_SOUND, AL_DISTANCE_MODEL</param>
        /// <returns>The double value described by param will be returned.</returns>
        [DllImport( "openal32.dll", EntryPoint = "alGetDouble", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl ), SuppressUnmanagedCodeSecurity( )]
        public static extern double Get( ALGetDouble param );
        // AL_API ALdouble AL_APIENTRY alGetDouble( ALenum param );
        */

        /// <summary>Error support. Obtain the most recent error generated in the AL state machine. When an error is detected by AL, a flag is set and the error code is recorded. Further errors, if they occur, do not affect this recorded code. When alGetError is called, the code is returned and the flag is cleared, so that a further error will again record its code.</summary>
        /// <returns>The first error that occured. can be used with AL.GetString. Returns an Alenum representing the error state. When an OpenAL error occurs, the error state is set and will not be changed until the error state is retrieved using alGetError. Whenever alGetError is called, the error state is cleared and the last state (the current state when the call was made) is returned. To isolate error detection to a specific portion of code, alGetError should be called before the isolated section to clear the current error state.</returns>
        [DllImport("openal32.dll", EntryPoint = "alGetError", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern AlError GetError();
        // AL_API ALenum AL_APIENTRY alGetError( void );

        #endregion State retrieval

        #region Extension support.

        ///<summary>This function tests if a specific Extension is available for the OpenAL driver.</summary>
        /// <param name="extname">A string naming the desired extension. Example: "EAX-RAM"</param>
        /// <returns>Returns True if the Extension is available or False if not available.</returns>
        [DllImport("openal32.dll", EntryPoint = "alIsExtensionPresent", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity()]
        public static extern bool IsExtensionPresent([In] string extname);
        // AL_API ALboolean AL_APIENTRY alIsExtensionPresent( const ALchar* extname );

        /// <summary>This function returns the address of an OpenAL extension function. Handle with care.</summary>
        /// <param name="fname">A string containing the function name.</param>
        /// <returns>The return value is a pointer to the specified function. The return value will be IntPtr.Zero if the function is not found.</returns>
        [DllImport("openal32.dll", EntryPoint = "alGetProcAddress", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity()]
        public static extern IntPtr GetProcAddress([In] string fname);
        // AL_API void* AL_APIENTRY alGetProcAddress( const ALchar* fname );

        /// <summary>This function returns the enumeration value of an OpenAL token, described by a string.</summary>
        /// <param name="ename">A string describing an OpenAL token. Example "AL_DISTANCE_MODEL"</param>
        /// <returns>Returns the actual ALenum described by a string. Returns 0 if the string doesn’t describe a valid OpenAL token.</returns>
        [DllImport("openal32.dll", EntryPoint = "alGetEnumValue", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi), SuppressUnmanagedCodeSecurity()]
        public static extern int GetEnumValue([In] string ename);
        // AL_API ALenum AL_APIENTRY alGetEnumValue( const ALchar* ename );

        #endregion Extension support.

        /* Listener
         * Listener represents the location and orientation of the
         * 'user' in 3D-space.
         * 
         * Properties include: -
         *
         * Gain         AL_GAIN         ALfloat
         * Position     AL_POSITION     ALfloat[3]
         * Velocity     AL_VELOCITY     ALfloat[3]
         * Orientation  AL_ORIENTATION  ALfloat[6] (Forward then Up vectors)
         */

        #region Set Listener parameters

        /// <summary>This function sets a floating-point property for the listener.</summary>
        /// <param name="param">The name of the attribute to be set: AlListenerf.Gain</param>
        /// <param name="value">The float value to set the attribute to.</param>
        [DllImport("openal32.dll", EntryPoint = "alListenerf", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Listener(AlListenerf param, float value);
        // AL_API void AL_APIENTRY alListenerf( ALenum param, ALfloat value );

        /// <summary>This function sets a floating-point property for the listener.</summary>
        /// <param name="param">The name of the attribute to set: AlListener3f.Position, AlListener3f.Velocity</param>
        /// <param name="value1">The value to set the attribute to.</param>
        /// <param name="value2">The value to set the attribute to.</param>
        /// <param name="value3">The value to set the attribute to.</param>
        [DllImport("openal32.dll", EntryPoint = "alListener3f", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Listener(AlListener3f param, float value1, float value2, float value3);
        // AL_API void AL_APIENTRY alListener3f( ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        /// <summary>This function sets a Math.Vector3 property for the listener.</summary>
        /// <param name="param">The name of the attribute to set: AlListener3f.Position, AlListener3f.Velocity</param>
        /// <param name="values">The Math.Vector3 to set the attribute to.</param>
        public static void Listener(AlListener3f param, ref Vector3f values)
        {
            Listener(param, values.X, values.Y, values.Z);
        }

        [DllImport("openal32.dll", EntryPoint = "alListenerfv", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        unsafe private static extern void ListenerPrivate(AlListenerfv param, float* values);
        // AL_API void AL_APIENTRY alListenerfv( ALenum param, const ALfloat* values );

        /// <summary>This function sets a floating-point vector property of the listener.</summary>
        /// <param name="param">The name of the attribute to be set: AlListener3f.Position, AlListener3f.Velocity, AlListenerfv.Orientation</param>
        /// <param name="values">Pointer to floating-point vector values.</param>
        public static void Listener(AlListenerfv param, ref float[] values)
        {
            unsafe
            {
                fixed (float* ptr = &values[0])
                {
                    ListenerPrivate(param, ptr);
                }
            }
        }

        /// <summary>This function sets two Math.Vector3 properties of the listener.</summary>
        /// <param name="param">The name of the attribute to be set: AlListenerfv.Orientation</param>
        /// <param name="at">A Math.Vector3 for the At-Vector.</param>
        /// <param name="up">A Math.Vector3 for the Up-Vector.</param>
        public static void Listener(AlListenerfv param, ref Vector3f at, ref Vector3f up)
        {
            float[] temp = new float[6];

            temp[0] = at.X;
            temp[1] = at.Y;
            temp[2] = at.Z;

            temp[3] = up.X;
            temp[4] = up.Y;
            temp[5] = up.Z;

            unsafe
            {
                fixed (float* ptr = &temp[0])
                {
                    ListenerPrivate(param, ptr);
                }
            }
        }

        // Not used by any Enums
        // AL_API void AL_APIENTRY alListeneri( ALenum param, ALint value );
        // AL_API void AL_APIENTRY alListener3i( ALenum param, ALint value1, ALint value2, ALint value3 );
        // AL_API void AL_APIENTRY alListeneriv( ALenum param, const ALint* values );

        #endregion Set Listener parameters

        #region Get Listener parameters

        /// <summary>This function retrieves a floating-point property of the listener.</summary>
        /// <param name="param">the name of the attribute to be retrieved: AlListenerf.Gain</param>
        /// <param name="value">a pointer to the floating-point value being retrieved.</param>
        [DllImport("openal32.dll", EntryPoint = "alGetListenerf", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void GetListener(AlListenerf param, [Out] out float value);
        // AL_API void AL_APIENTRY alGetListenerf( ALenum param, ALfloat* value );

        /// <summary>This function retrieves a set of three floating-point values from a property of the listener.</summary>
        /// <param name="param">The name of the attribute to be retrieved: AlListener3f.Position, AlListener3f.Velocity</param>
        /// <param name="value1">The first floating-point value being retrieved.</param>
        /// <param name="value2">The second floating-point value  being retrieved.</param>
        /// <param name="value3">The third floating-point value  being retrieved.</param>
        [DllImport("openal32.dll", EntryPoint = "alGetListener3f", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void GetListener(AlListener3f param, [Out] out float value1, [Out] out float value2, [Out] out float value3);
        // AL_API void AL_APIENTRY alGetListener3f( ALenum param, ALfloat *value1, ALfloat *value2, ALfloat *value3 );

        /// <summary>This function retrieves a Math.Vector3 from a property of the listener.</summary>
        /// <param name="param">The name of the attribute to be retrieved: AlListener3f.Position, AlListener3f.Velocity</param>
        /// <param name="values">A Math.Vector3 to hold the three floats being retrieved.</param>
        public static void GetListener(AlListener3f param, out Vector3f values)
        {
            float x, y, z;
            GetListener(param, out x, out y, out z);
            values = new Vector3f(x, y, z);
        }

        /// <summary>This function retrieves a floating-point vector property of the listener. You must pin it manually.</summary>
        /// <param name="param">the name of the attribute to be retrieved: AlListener3f.Position, AlListener3f.Velocity, AlListenerfv.Orientation</param>
        /// <param name="values">A pointer to the floating-point vector value being retrieved.</param>
        [DllImport("openal32.dll", EntryPoint = "alGetListenerfv", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        unsafe public static extern void GetListener(AlListenerfv param, float* values);
        // AL_API void AL_APIENTRY alGetListenerfv( ALenum param, ALfloat* values );

        /// <summary>This function retrieves two Math.Vector3 properties of the listener.</summary>
        /// <param name="param">the name of the attribute to be retrieved: AlListenerfv.Orientation</param>
        /// <param name="at">A Math.Vector3 for the At-Vector.</param>
        /// <param name="up">A Math.Vector3 for the Up-Vector.</param>
        public static void GetListener(AlListenerfv param, out Vector3f at, out Vector3f up)
        {
            unsafe
            {
                float* ptr = stackalloc float[6];
                GetListener(param, ptr);

                at = new Vector3f(ptr[0], ptr[1], ptr[2]);
                up = new Vector3f(ptr[3], ptr[4], ptr[5]);
            }
        }

        // Not used by any Enum:
        // AL_API void AL_APIENTRY alGetListeneri( ALenum param, ALint* value );
        // AL_API void AL_APIENTRY alGetListener3i( ALenum param, ALint *value1, ALint *value2, ALint *value3 );
        // AL_API void AL_APIENTRY alGetListeneriv( ALenum param, ALint* values );

        #endregion Get Listener parameters

        /* Source
         * Sources represent individual sound objects in 3D-space.
         * Sources take the PCM buffer provided in the specified Buffer,
         * apply Source-specific modifications, and then
         * submit them to be mixed according to spatial arrangement etc.
         * 
         * Properties include: -
         *
        
         * Position                          AL_POSITION             ALfloat[3]
         * Velocity                          AL_VELOCITY             ALfloat[3]
         * Direction                         AL_DIRECTION            ALfloat[3]

         * Head Relative Mode                AL_SOURCE_RELATIVE      ALint (AL_TRUE or AL_FALSE)
         * Looping                           AL_LOOPING              ALint (AL_TRUE or AL_FALSE)
         * 
         * Reference Distance                AL_REFERENCE_DISTANCE   ALfloat
         * Max Distance                      AL_MAX_DISTANCE         ALfloat
         * RollOff Factor                    AL_ROLLOFF_FACTOR       ALfloat
         * Pitch                             AL_PITCH                ALfloat
         * Gain                              AL_GAIN                 ALfloat
         * Min Gain                          AL_MIN_GAIN             ALfloat
         * Max Gain                          AL_MAX_GAIN             ALfloat
         * Inner Angle                       AL_CONE_INNER_ANGLE     ALint or ALfloat
         * Outer Angle                       AL_CONE_OUTER_ANGLE     ALint or ALfloat
         * Cone Outer Gain                   AL_CONE_OUTER_GAIN      ALint or ALfloat 
         * 
         * MS Offset                         AL_MSEC_OFFSET          ALint or ALfloat
         * Byte Offset                       AL_BYTE_OFFSET          ALint or ALfloat
         * Sample Offset                     AL_SAMPLE_OFFSET        ALint or ALfloat
         * Attached Buffer                   AL_BUFFER               ALint
         * 
         * State (Query only)                AL_SOURCE_STATE         ALint
         * Buffers Queued (Query only)       AL_BUFFERS_QUEUED       ALint
         * Buffers Processed (Query only)    AL_BUFFERS_PROCESSED    ALint
         */

        #region Create Source objects

        #region GenSources()

        /// <summary>This function generates one or more sources. References to sources are uint values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter AlSourcei).</summary>
        /// <param name="n">The number of sources to be generated.</param>
        /// <param name="sources">Pointer to an array of uint values which will store the names of the new sources.</param>
        [DllImport("openal32.dll", EntryPoint = "alGenSources", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public unsafe static extern void GenSources(int n, [Out] uint* sources);
        // AL_API void AL_APIENTRY alGenSources( ALsizei n, ALuint* Sources );

        /// <summary>This function generates one or more sources. References to sources are int values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter AlSourcei).</summary>
        /// <param name="sources">Pointer to an array of int values which will store the names of the new sources.</param>
        public static void GenSources(uint[] sources)
        {
            unsafe
            {
                fixed (uint* ptr = &sources[0])
                {
                    GenSources(sources.Length, ptr);
                }
            }
        }

        /// <summary>This function generates one source only. References to sources are int values, which are used wherever a source reference is needed (in calls such as AL.DeleteSources and AL.Source with parameter AlSourcei).</summary>
        /// <returns>Pointer to an int value which will store the name of the new source.</returns>
        public static uint GenSource()
        {
            unsafe
            {
                uint temp;
                GenSources(1, &temp);
                return temp;
            }
        }

        #endregion GenSources()

        #region DeleteSources()

        /// <summary>This function deletes one or more sources.</summary>
        /// <param name="n">The number of sources to be deleted.</param>
        /// <param name="sources">Pointer to an array of source names identifying the sources to be deleted.</param>
        [DllImport("openal32.dll", EntryPoint = "alDeleteSources", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public unsafe static extern void DeleteSources(int n, [In] uint* sources); // Delete Source objects 
        // AL_API void AL_APIENTRY alDeleteSources( ALsizei n, const ALuint* Sources );

        /// <summary>This function deletes one or more sources.</summary>
        /// <param name="sources">An array of source names identifying the sources to be deleted.</param>
        public static void DeleteSources(uint[] sources)
        {
            unsafe
            {
                fixed (uint* ptr = &sources[0])
                {
                    DeleteBuffers(sources.Length, ptr);
                }
            }
        }

        /// <summary>This function deletes one source only.</summary>
        /// <param name="source">Pointer to a source name identifying the source to be deleted.</param>
        public static void DeleteSource(uint source)
        {
            unsafe
            {
                DeleteSources(1, &source);
            }
        }

        #endregion DeleteSources()

        #region IsSource()

        /// <summary>This function tests if a source name is valid, returning True if valid and False if not.</summary>
        /// <param name="sid">A source name to be tested for validity</param>
        /// <returns>Success.</returns>
        [DllImport("openal32.dll", EntryPoint = "alIsSource", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern bool IsSource(uint sid);
        // AL_API ALboolean AL_APIENTRY alIsSource( ALuint sid );

        #endregion IsSource()

        #endregion Create Source objects

        #region Set Source parameters

        #region Sourcef

        /// <summary>This function sets a floating-point property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set</param>
        /// <param name="param">The name of the attribute to set: AlSourcef.Pitch, Gain, MinGain, MaxGain, MaxDistance, RolloffFactor, ConeOuterGain, ConeInnerAngle, ConeOuterAngle, ReferenceDistance, EfxAirAbsorptionFactor, EfxRoomRolloffFactor, EfxConeOuterGainHighFrequency.</param>
        /// <param name="value">The value to set the attribute to.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourcef", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Source(uint sid, AlSourcef param, float value);
        // AL_API void AL_APIENTRY alSourcef( ALuint sid, ALenum param, ALfloat value );

        #endregion Sourcef

        #region Source3f

        /// <summary>This function sets a source property requiring three floating-point values.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: AlSource3f.Position, Velocity, Direction.</param>
        /// <param name="value1">The three ALfloat values which the attribute will be set to.</param>
        /// <param name="value2">The three ALfloat values which the attribute will be set to.</param>
        /// <param name="value3">The three ALfloat values which the attribute will be set to.</param>
        [DllImport("openal32.dll", EntryPoint = "alSource3f", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Source(uint sid, AlSource3f param, float value1, float value2, float value3);
        // AL_API void AL_APIENTRY alSource3f( ALuint sid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        /// <summary>This function sets a source property requiring three floating-point values.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: AlSource3f.Position, Velocity, Direction.</param>
        /// <param name="values">A Math.Vector3 which the attribute will be set to.</param>
        public static void Source(uint sid, AlSource3f param, ref Vector3f values)
        {
            Source(sid, param, values.X, values.Y, values.Z);
        }

        #endregion Source3f

        #region Sourcei

        /// <summary>This function sets an integer property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: AlSourcei.SourceRelative, ConeInnerAngle, ConeOuterAngle, Looping, Buffer, SourceState.</param>
        /// <param name="value">The value to set the attribute to.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourcei", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Source(uint sid, AlSourcei param, int value);
        // AL_API void AL_APIENTRY alSourcei( ALuint sid, ALenum param, ALint value ); 

        /// <summary>This function sets an bool property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: AlSourceb.SourceRelative, Looping.</param>
        /// <param name="value">The value to set the attribute to.</param>
        public static void Source(uint sid, AlSourceb param, bool value)
        {
            Source(sid, (AlSourcei)param, (value) ? 1 : 0);
        }

        #endregion Sourcei

        #region Source3i

        /// <summary>This function sets 3 integer properties of a source. This property is used to establish connections between Sources and Auxiliary Effect Slots.</summary>
        /// <param name="sid">Source name whose attribute is being set.</param>
        /// <param name="param">The name of the attribute to set: EfxAuxiliarySendFilter</param>
        /// <param name="value1">The value to set the attribute to. (EFX Extension) The destination Auxiliary Effect Slot ID</param>
        /// <param name="value2">The value to set the attribute to. (EFX Extension) The Auxiliary Send number.</param>
        ///<param name="value3">The value to set the attribute to. (EFX Extension) optional Filter ID.</param>
        [DllImport("openal32.dll", EntryPoint = "alSource3i", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void Source(uint sid, AlSource3i param, int value1, int value2, int value3);
        // AL_API void AL_APIENTRY alSource3i( ALuint sid, ALenum param, ALint value1, ALint value2, ALint value3 );      

        #endregion Source3i

        // Not used by any Enum:
        // AL_API void AL_APIENTRY alSourcefv( ALuint sid, ALenum param, const ALfloat* values );
        // AL_API void AL_APIENTRY alSourceiv( ALuint sid, ALenum param, const ALint* values );

        #endregion Set Source parameters

        #region Get Source parameters

        #region GetSourcef

        /// <summary>This function retrieves a floating-point property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to set: AlSourcef.Pitch, Gain, MinGain, MaxGain, MaxDistance, RolloffFactor, ConeOuterGain, ConeInnerAngle, ConeOuterAngle, ReferenceDistance, EfxAirAbsorptionFactor, EfxRoomRolloffFactor, EfxConeOuterGainHighFrequency.</param>
        /// <param name="value">A pointer to the floating-point value being retrieved</param>
        [DllImport("openal32.dll", EntryPoint = "alGetSourcef", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void GetSource(uint sid, AlSourcef param, [Out] out float value);
        // AL_API void AL_APIENTRY alGetSourcef( ALuint sid, ALenum param, ALfloat* value );

        #endregion GetSourcef

        #region GetSource3f

        /// <summary>This function retrieves three floating-point values representing a property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">the name of the attribute being retrieved: AlSource3f.Position, Velocity, Direction.</param>
        /// <param name="value1">Pointer to the value to retrieve.</param>
        /// <param name="value2">Pointer to the value to retrieve.</param>
        /// <param name="value3">Pointer to the value to retrieve.</param>
        [DllImport("openal32.dll", EntryPoint = "alGetSource3f", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void GetSource(uint sid, AlSource3f param, [Out] out float value1, [Out] out float value2, [Out] out float value3);
        // AL_API void AL_APIENTRY alGetSource3f( ALuint sid, ALenum param, ALfloat* value1, ALfloat* value2, ALfloat* value3);

        /// <summary>This function retrieves three floating-point values representing a property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">the name of the attribute being retrieved: AlSource3f.Position, Velocity, Direction.</param>
        /// <param name="values">A Math.Vector3 to retrieve the values to.</param>
        public static void GetSource(uint sid, AlSource3f param, out Vector3f values)
        {
            float x, y, z;
            GetSource((uint)sid, param, out x, out y, out z);
            values = new Vector3f(x, y, z);
        }

        #endregion GetSource3f

        #region GetSourcei

        /// <summary>This function retrieves an integer property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to retrieve: AlSourcei.SourceRelative, Buffer, SourceState, BuffersQueued, BuffersProcessed.</param>
        /// <param name="value">A pointer to the integer value being retrieved.</param>
        [DllImport("openal32.dll", EntryPoint = "alGetSourcei", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void GetSource(uint sid, AlGetSourcei param, [Out] out int value);
        // AL_API void AL_APIENTRY alGetSourcei( ALuint sid,  ALenum param, ALint* value );
        
        /// <summary>This function retrieves a bool property of a source.</summary>
        /// <param name="sid">Source name whose attribute is being retrieved.</param>
        /// <param name="param">The name of the attribute to get: AlSourceb.SourceRelative, Looping.</param>
        /// <param name="value">A pointer to the bool value being retrieved.</param>
        public static void GetSource(uint sid, AlSourceb param, out bool value)
        {
            int result;
            GetSource(sid, (AlGetSourcei)param, out result);
            value = result != 0;
        }

        #endregion GetSourcei

        // Not used by any Enum:
        // AL_API void AL_APIENTRY alGetSource3i( ALuint sid, ALenum param, ALint* value1, ALint* value2, ALint* value3);
        // AL_API void AL_APIENTRY alGetSourcefv( ALuint sid, ALenum param, ALfloat* values );
        // AL_API void AL_APIENTRY alGetSourceiv( ALuint sid,  ALenum param, ALint* values );

        #endregion Get Source parameters

        #region Source vector based playback calls

        #region SourcePlay

        /// <summary>This function plays a set of sources. The playing sources will have their state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="ns">The number of sources to be played.</param>
        /// <param name="sids">A pointer to an array of sources to be played.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourcePlayv"), SuppressUnmanagedCodeSecurity]
        unsafe public static extern void SourcePlay(int ns, [In] uint* sids);
        // AL_API void AL_APIENTRY alSourcePlayv( ALsizei ns, const ALuint *sids );

        /// <summary>This function plays a set of sources. The playing sources will have their state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="ns">The number of sources to be played.</param>
        /// <param name="sids">A pointer to an array of sources to be played.</param>
        public static void SourcePlay(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    SourcePlay(ns, ptr);
                }
            }
        }

        #endregion SourcePlay

        #region SourceStop

        /// <summary>This function stops a set of sources. The stopped sources will have their state changed to ALSourceState.Stopped.</summary>
        /// <param name="ns">The number of sources to stop.</param>
        /// <param name="sids">A pointer to an array of sources to be stopped.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourceStopv"), SuppressUnmanagedCodeSecurity]
        unsafe public static extern void SourceStop(int ns, [In] uint* sids);
        // AL_API void AL_APIENTRY alSourceStopv( ALsizei ns, const ALuint *sids );

        /// <summary>This function stops a set of sources. The stopped sources will have their state changed to ALSourceState.Stopped.</summary>
        /// <param name="ns">The number of sources to stop.</param>
        /// <param name="sids">A pointer to an array of sources to be stopped.</param>
        public static void SourceStop(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    SourceStop(ns, ptr);
                }
            }
        }

        #endregion SourceStop

        #region SourceRewind

        /// <summary>This function stops a set of sources and sets all their states to ALSourceState.Initial.</summary>
        /// <param name="ns">The number of sources to be rewound.</param>
        /// <param name="sids">A pointer to an array of sources to be rewound.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourceRewindv"), SuppressUnmanagedCodeSecurity]
        unsafe public static extern void SourceRewind(int ns, [In] uint* sids);
        // AL_API void AL_APIENTRY alSourceRewindv( ALsizei ns, const ALuint *sids );

        /// <summary>This function stops a set of sources and sets all their states to ALSourceState.Initial.</summary>
        /// <param name="ns">The number of sources to be rewound.</param>
        /// <param name="sids">A pointer to an array of sources to be rewound.</param>
        public static void SourceRewind(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    SourceRewind(ns, ptr);
                }
            }
        }

        #endregion SourceRewind

        #region SourcePause

        /// <summary>This function pauses a set of sources. The paused sources will have their state changed to ALSourceState.Paused.</summary>
        /// <param name="ns">The number of sources to be paused.</param>
        /// <param name="sids">A pointer to an array of sources to be paused.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourcePausev"), SuppressUnmanagedCodeSecurity]
        unsafe public static extern void SourcePause(int ns, [In] uint* sids);
        // AL_API void AL_APIENTRY alSourcePausev( ALsizei ns, const ALuint *sids );

        /// <summary>This function pauses a set of sources. The paused sources will have their state changed to ALSourceState.Paused.</summary>
        /// <param name="ns">The number of sources to be paused.</param>
        /// <param name="sids">A pointer to an array of sources to be paused.</param>
        public static void SourcePause(int ns, uint[] sids)
        {
            unsafe
            {
                fixed (uint* ptr = sids)
                {
                    SourcePause(ns, ptr);
                }
            }
        }

        #endregion SourcePause

        #endregion Source vector based playback calls

        #region Source based playback calls

        #region SourcePlay

        /// <summary>This function plays, replays or resumes a source. The playing source will have it's state changed to ALSourceState.Playing. When called on a source which is already playing, the source will restart at the beginning. When the attached buffer(s) are done playing, the source will progress to the ALSourceState.Stopped state.</summary>
        /// <param name="sid">The name of the source to be played.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourcePlay", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void SourcePlay(uint sid);
        // AL_API void AL_APIENTRY alSourcePlay( ALuint sid );

        #endregion SourcePlay

        #region SourceStop

        /// <summary>This function stops a source. The stopped source will have it's state changed to ALSourceState.Stopped.</summary>
        /// <param name="sid">The name of the source to be stopped.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourceStop", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void SourceStop(uint sid);

        #endregion SourceStop

        #region SourceRewind

        /// <summary>This function stops the source and sets its state to ALSourceState.Initial.</summary>
        /// <param name="sid">The name of the source to be rewound.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourceRewind", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void SourceRewind(uint sid);

        #endregion SourceRewind

        #region SourcePause

        /// <summary>This function pauses a source. The paused source will have its state changed to ALSourceState.Paused.</summary>
        /// <param name="sid">The name of the source to be paused.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourcePause", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void SourcePause(uint sid);
        // AL_API void AL_APIENTRY alSourcePause( ALuint sid );

        #endregion SourcePause

        #endregion Source based playback calls

        #region Source Queuing

        #region SourceQueueBuffers

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter AlGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="sid">The name of the source to queue buffers onto.</param>
        /// <param name="numEntries">The number of buffers to be queued.</param>
        /// <param name="bids">A pointer to an array of buffer names to be queued.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourceQueueBuffers"), SuppressUnmanagedCodeSecurity]
        unsafe public static extern void SourceQueueBuffers(uint sid, int numEntries, [In] uint* bids);
        // AL_API void AL_APIENTRY alSourceQueueBuffers( ALuint sid, ALsizei numEntries, const ALuint *bids );

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter AlGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="sid">The name of the source to queue buffers onto.</param>
        /// <param name="numEntries">The number of buffers to be queued.</param>
        /// <param name="bids">A pointer to an array of buffer names to be queued.</param>
        public static void SourceQueueBuffers(uint sid, int numEntries, uint[] bids)
        {
            unsafe
            {
                fixed (uint* ptr = bids)
                {
                    SourceQueueBuffers(sid, numEntries, ptr);
                }
            }
        }

        /// <summary>This function queues a set of buffers on a source. All buffers attached to a source will be played in sequence, and the number of processed buffers can be detected using AL.GetSource with parameter AlGetSourcei.BuffersProcessed. When first created, a source will be of type ALSourceType.Undetermined. A successful AL.SourceQueueBuffers call will change the source type to ALSourceType.Streaming.</summary>
        /// <param name="source">The name of the source to queue buffers onto.</param>
        /// <param name="buffer">The name of the buffer to be queued.</param>
        public static void SourceQueueBuffer(uint source, uint buffer)
        {
            unsafe
            {
                SourceQueueBuffers(source, 1, &buffer);
            }
        }

        #endregion SourceQueueBuffers

        #region SourceUnqueueBuffers

        /// <summary>This function unqueues a set of buffers attached to a source. The number of processed buffers can be detected using AL.GetSource with parameter AlGetSourcei.BuffersProcessed, which is the maximum number of buffers that can be unqueued using this call. The unqueue operation will only take place if all n buffers can be removed from the queue.</summary>
        /// <param name="sid">The name of the source to unqueue buffers from.</param>
        /// <param name="numEntries">The number of buffers to be unqueued.</param>
        /// <param name="bids">A pointer to an array of buffer names that were removed.</param>
        [DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers"), SuppressUnmanagedCodeSecurity]
        unsafe public static extern void SourceUnqueueBuffers(uint sid, int numEntries, [In] uint* bids);
        // AL_API void AL_APIENTRY alSourceUnqueueBuffers( ALuint sid, ALsizei numEntries, ALuint *bids );

        /// <summary>This function unqueues a set of buffers attached to a source. The number of processed buffers can be detected using AL.GetSource with parameter AlGetSourcei.BuffersProcessed, which is the maximum number of buffers that can be unqueued using this call. The unqueue operation will only take place if all n buffers can be removed from the queue.</summary>
        /// <param name="sid">The name of the source to unqueue buffers from.</param>
        /// <param name="numEntries">The number of buffers to be unqueued.</param>
        /// <param name="bids">A pointer to an array of buffer names that were removed.</param>
        public static void SourceUnqueueBuffers(uint sid, int numEntries, [Out] uint[] bids)
        {
            unsafe
            {
                fixed (uint* ptr = bids)
                {
                    SourceUnqueueBuffers(sid, numEntries, ptr);
                }
            }
        }

        /// <summary>This function unqueues a set of buffers attached to a source. The number of processed buffers can be detected using AL.GetSource with parameter AlGetSourcei.BuffersProcessed, which is the maximum number of buffers that can be unqueued using this call. The unqueue operation will only take place if all n buffers can be removed from the queue.</summary>
        /// <param name="sid">The name of the source to unqueue buffers from.</param>
        public static uint SourceUnqueueBuffer(uint sid)
        {
            unsafe
            {
                uint buf;
                SourceUnqueueBuffers(sid, 1, &buf);
                return buf;
            }
        }

        #endregion SourceUnqueueBuffers

        #endregion Source Queuing

        /*
         * Buffer
         * Buffer objects are storage space for sample buffer.
         * Buffers are referred to by Sources. One Buffer can be used
         * by multiple Sources.
         *
         * Properties include: -
         *
         * Frequency (Query only)    AL_FREQUENCY      ALint
         * Size (Query only)         AL_SIZE           ALint
         * Bits (Query only)         AL_BITS           ALint
         * Channels (Query only)     AL_CHANNELS       ALint
         */

        #region Buffer objects

        #region GenBuffers

        /// <summary>This function generates one or more buffers, which contain audio buffer (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter AlSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="n">The number of buffers to be generated.</param>
        /// <param name="buffers">Pointer to an array of uint values which will store the names of the new buffers.</param>
        [DllImport("openal32.dll", EntryPoint = "alGenBuffers", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        public unsafe static extern void GenBuffers(int n, [Out] uint* buffers);
        // AL_API void AL_APIENTRY alGenBuffers( ALsizei n, ALuint* Buffers );

        /// <summary>This function generates one or more buffers, which contain audio buffer (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter AlSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="n">The number of buffers to be generated.</param>
        /// <param name="buffers">Pointer to an array of uint values which will store the names of the new buffers.</param>
        public static void GenBuffers(uint[] buffers)
        {
            unsafe
            {
                fixed (uint* ptr = &buffers[0])
                {
                    GenBuffers(buffers.Length, ptr);
                }
            }
        }

        /// <summary>This function generates one buffer only, which contain audio data (see AL.BufferData). References to buffers are uint values, which are used wherever a buffer reference is needed (in calls such as AL.DeleteBuffers, AL.Source with parameter AlSourcei, AL.SourceQueueBuffers, and AL.SourceUnqueueBuffers).</summary>
        /// <param name="buffer">Pointer to an uint value which will store the names of the new buffer.</param>
        public static uint GenBuffer()
        {
            unsafe
            {
                uint buffer;
                GenBuffers(1, &buffer);
                return buffer;
            }
        }

        #endregion GenBuffers

        #region DeleteBuffers

        /// <summary>This function deletes one or more buffers, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (AlSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="n">The number of buffers to be deleted.</param>
        /// <param name="buffers">Pointer to an array of buffer names identifying the buffers to be deleted.</param>
        [DllImport("openal32.dll", EntryPoint = "alDeleteBuffers", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        unsafe public static extern void DeleteBuffers(int n, [In] uint* buffers);
        // AL_API void AL_APIENTRY alDeleteBuffers( ALsizei n, const ALuint* Buffers );

        /// <summary>This function deletes one buffer only, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (AlSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="buffers">Pointer to a buffer name identifying the buffer to be deleted.</param>
        public static void DeleteBuffers(uint[] buffers)
        {
            if (buffers == null) throw new ArgumentNullException();
            if (buffers.Length == 0) throw new ArgumentOutOfRangeException();
            unsafe
            {
                fixed (uint* ptr = &buffers[0])
                {
                    DeleteBuffers(buffers.Length, ptr);
                }
            }
        }

        /// <summary>This function deletes one buffer only, freeing the resources used by the buffer. Buffers which are attached to a source can not be deleted. See AL.Source (AlSourcei) and AL.SourceUnqueueBuffers for information on how to detach a buffer from a source.</summary>
        /// <param name="buffer">Pointer to a buffer name identifying the buffer to be deleted.</param>
        public static void DeleteBuffer(uint buffer)
        {
            unsafe
            {
                DeleteBuffers(1, &buffer);
            }
        }

        #endregion DeleteBuffers

        #region IsBuffer

        /// <summary>This function tests if a buffer name is valid, returning True if valid, False if not.</summary>
        /// <param name="bid">A buffer Handle previously allocated with <see cref="GenBuffers(int)"/>.</param>
        /// <returns>Success.</returns>
        [DllImport("openal32.dll", EntryPoint = "alIsBuffer", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern bool IsBuffer(uint bid);
        // AL_API ALboolean AL_APIENTRY alIsBuffer( ALuint bid );

        /// <summary>This function tests if a buffer name is valid, returning True if valid, False if not.</summary>
        /// <param name="bid">A buffer Handle previously allocated with <see cref="GenBuffers(int)"/>.</param>
        /// <returns>Success.</returns>
        public static bool IsBuffer(int bid)
        {
            uint temp = (uint)bid;
            return IsBuffer(temp);
        }

        #endregion IsBuffer

        #region BufferData

        /// <summary>This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function may be used by extensions to load other buffer types as well.</summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: ALFormat.Mono8, ALFormat.Mono16, ALFormat.Stereo8, ALFormat.Stereo16.</param>
        /// <param name="buffer">Pointer to a pinned audio buffer.</param>
        /// <param name="size">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        [DllImport("openal32.dll", EntryPoint = "alBufferData", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void BufferData(uint bid, int format, IntPtr buffer, int size, int freq);
        // AL_API void AL_APIENTRY alBufferData( ALuint bid, ALenum format, const ALvoid* buffer, ALsizei size, ALsizei freq );

        /// <summary>This function fills a buffer with audio buffer. All the pre-defined formats are PCM buffer, but this function may be used by extensions to load other buffer types as well.</summary>
        /// <param name="bid">buffer Handle/Name to be filled with buffer.</param>
        /// <param name="format">Format type from among the following: ALFormat.Mono8, ALFormat.Mono16, ALFormat.Stereo8, ALFormat.Stereo16.</param>
        /// <param name="buffer">The audio buffer.</param>
        /// <param name="size">The size of the audio buffer in bytes.</param>
        /// <param name="freq">The frequency of the audio buffer.</param>
        public static void BufferData<TBuffer>(uint bid, int format, TBuffer[] buffer, int size, int freq)
            where TBuffer : struct
        {
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try { BufferData(bid, format, handle.AddrOfPinnedObject(), size, freq); }
            finally { handle.Free(); }
        }

        #endregion BufferData

        #endregion Buffer objects

        #region Set Buffer parameters (currently parameters can only be read)

        /*
        Remarks (from Manual)
         * There are no relevant buffer properties defined in OpenAL 1.1 which can be affected by this call,
         * but this function may be used by OpenAL extensions.

        // AL_API void AL_APIENTRY alBufferf( ALuint bid, ALenum param, ALfloat value );
        // AL_API void AL_APIENTRY alBufferfv( ALuint bid, ALenum param, const ALfloat* values );
        // AL_API void AL_APIENTRY alBufferi( ALuint bid, ALenum param, ALint value );
        // AL_API void AL_APIENTRY alBuffer3i( ALuint bid, ALenum param, ALint value1, ALint value2, ALint value3 );
        // AL_API void AL_APIENTRY alBufferiv( ALuint bid, ALenum param, const ALint* values );
        // AL_API void AL_APIENTRY alBuffer3f( ALuint bid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );
        */

        /*
        [DllImport( Al.Lib, EntryPoint = "alBuffer3f", ExactSpelling = true, CallingConvention = Al.Style ), SuppressUnmanagedCodeSecurity( )]
        public static extern void Buffer3f( uint bid, ALenum param, ALfloat value1, ALfloat value2, ALfloat value3 );

        public static void Bufferv3( uint bid, Alenum param, ref Vector3 values )
        {
            Buffer3f( bid, param, values.X, values.Y, values.Z );
        }*/

        #endregion Set Buffer parameters

        #region Get Buffer parameters

        #region GetBufferi

        /// <summary>This function retrieves an integer property of a buffer.</summary>
        /// <param name="bid">Buffer name whose attribute is being retrieved</param>
        /// <param name="param">The name of the attribute to be retrieved: ALGetBufferi.Frequency, Bits, Channels, Size, and the currently hidden AL_DATA (dangerous).</param>
        /// <param name="value">A pointer to an int to hold the retrieved buffer</param>
        [DllImport("openal32.dll", EntryPoint = "alGetBufferi", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void GetBuffer(uint bid, AlGetBufferi param, [Out] out int value);
        // AL_API void AL_APIENTRY alGetBufferi( ALuint bid, ALenum param, ALint* value );


        #endregion GetBufferi

        // AL_API void AL_APIENTRY alGetBufferf( ALuint bid, ALenum param, ALfloat* value );
        // AL_API void AL_APIENTRY alGetBuffer3f( ALuint bid, ALenum param, ALfloat* value1, ALfloat* value2, ALfloat* value3);
        // AL_API void AL_APIENTRY alGetBufferfv( ALuint bid, ALenum param, ALfloat* values );
        // AL_API void AL_APIENTRY alGetBuffer3i( ALuint bid, ALenum param, ALint* value1, ALint* value2, ALint* value3);
        // AL_API void AL_APIENTRY alGetBufferiv( ALuint bid, ALenum param, ALint* values );

        #endregion Get Buffer parameters

        #region Global Parameters

        /// <summary>AL.DopplerFactor is a simple scaling of source and listener velocities to exaggerate or deemphasize the Doppler (pitch) shift resulting from the calculation.</summary>
        /// <param name="value">A negative value will result in an error, the command is then ignored. The default value is 1f. The current setting can be queried using AL.Get with parameter AlGetFloat.SpeedOfSound.</param>
        [DllImport("openal32.dll", EntryPoint = "alDopplerFactor", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void DopplerFactor(float value);
        // AL_API void AL_APIENTRY alDopplerFactor( ALfloat value );

        /// <summary>This function is deprecated and should not be used.</summary>
        /// <param name="value">The default is 1.0f.</param>
        [DllImport("openal32.dll", EntryPoint = "alDopplerVelocity", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void DopplerVelocity(float value);
        // AL_API void AL_APIENTRY alDopplerVelocity( ALfloat value );

        /// <summary>AL.SpeedOfSound allows the application to change the reference (propagation) speed used in the Doppler calculation. The source and listener velocities should be expressed in the same units as the speed of sound.</summary>
        /// <param name="value">A negative or zero value will result in an error, and the command is ignored. Default: 343.3f (appropriate for velocity units of meters and air as the propagation medium). The current setting can be queried using AL.Get with parameter AlGetFloat.SpeedOfSound.</param>
        [DllImport("openal32.dll", EntryPoint = "alSpeedOfSound", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void SpeedOfSound(float value);
        // AL_API void AL_APIENTRY alSpeedOfSound( ALfloat value );

        /// <summary>This function selects the OpenAL distance model – ALDistanceModel.InverseDistance, ALDistanceModel.InverseDistanceClamped, ALDistanceModel.LinearDistance, ALDistanceModel.LinearDistanceClamped, ALDistanceModel.ExponentDistance, ALDistanceModel.ExponentDistanceClamped, or ALDistanceModel.None. The default distance model in OpenAL is ALDistanceModel.InverseDistanceClamped.</summary>
        /// <remarks>
        /// The ALDistanceModel .InverseDistance model works according to the following formula:
        /// gain = AlSourcef.ReferenceDistance / (AlSourcef.ReferenceDistance + AlSourcef.RolloffFactor * (distance – AlSourcef.ReferenceDistance));
        /// 
        /// The ALDistanceModel .InverseDistanceClamped model works according to the following formula:
        /// distance = max(distance,AlSourcef.ReferenceDistance);
        /// distance = min(distance,AlSourcef.MaxDistance);
        /// gain = AlSourcef.ReferenceDistance / (AlSourcef.ReferenceDistance + AlSourcef.RolloffFactor * (distance – AlSourcef.ReferenceDistance));
        /// 
        /// The ALDistanceModel.LinearDistance model works according to the following formula: 
        /// distance = min(distance, AlSourcef.MaxDistance) // avoid negative gain
        /// gain = (1 – AlSourcef.RolloffFactor * (distance – AlSourcef.ReferenceDistance) / (AlSourcef.MaxDistance – AlSourcef.ReferenceDistance))
        /// 
        /// The ALDistanceModel.LinearDistanceClamped model works according to the following formula:
        /// distance = max(distance, AlSourcef.ReferenceDistance)
        /// distance = min(distance, AlSourcef.MaxDistance)
        /// gain = (1 – AlSourcef.RolloffFactor * (distance – AlSourcef.ReferenceDistance) / (AlSourcef.MaxDistance – AlSourcef.ReferenceDistance))
        /// 
        /// The ALDistanceModel.ExponentDistance model works according to the following formula:
        /// gain = (distance / AlSourcef.ReferenceDistance) ^ (- AlSourcef.RolloffFactor) 
        /// 
        /// The ALDistanceModel.ExponentDistanceClamped model works according to the following formula:
        /// distance = max(distance, AlSourcef.ReferenceDistance)
        /// distance = min(distance, AlSourcef.MaxDistance)
        /// gain = (distance / AlSourcef.ReferenceDistance) ^ (- AlSourcef.RolloffFactor)
        /// 
        /// The ALDistanceModel.None model works according to the following formula:
        /// gain = 1f;
        /// </remarks>
        /// <param name="distancemodel"></param>
        [DllImport("openal32.dll", EntryPoint = "alDistanceModel", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity()]
        public static extern void DistanceModel(AlDistanceModel distancemodel);
        // AL_API void AL_APIENTRY alDistanceModel( ALenum distanceModel );

        #endregion Global Parameters
    }
}