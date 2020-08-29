Imports System.Runtime.InteropServices

Namespace Direct2D

    ''' <summary>
    ''' Represents a geometry resource And defines a set of helper methods for
    ''' manipulating And measuring geometric shapes. Interfaces that inherit from
    ''' ID2D1Geometry define specific shapes.
    ''' </summary>
    <ComImport(), Guid("2cd906a1-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1Geometry
        Inherits ID2D1Resource

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)



        'STDMETHOD(GetBounds)(
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    _Out_ D2D1_RECT_F *bounds 
        '    ) CONST PURE;
        ''' <summary>
        ''' Retrieve the bounds of the geometry, with an optional applied transform.
        ''' </summary>
        Function GetBounds(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                           <Out(), MarshalAs(UnmanagedType.Struct)> ByRef bounds As D2D1_RECT_F) As HRESULT


        'STDMETHOD(GetWidenedBounds)(
        '    FLOAT strokeWidth,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_ D2D1_RECT_F *bounds 
        '    ) CONST PURE;
        ''' <summary>
        ''' Get the bounds of the corresponding geometry after it has been widened Or have
        ''' an optional pen style applied.
        ''' </summary>
        Function GetWidenedBounds(ByVal strokeWidth As Single,
                                 <[In](), MarshalAs(UnmanagedType.Interface)> ByVal strokeStyle As ID2D1StrokeStyle,
                                 <[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                                  ByVal flatteningTolerance As Single,
                                 <Out(), MarshalAs(UnmanagedType.Struct)> ByRef bounds As D2D1_RECT_F) As HRESULT


        'STDMETHOD(StrokeContainsPoint)(
        '    D2D1_POINT_2F point,
        '    FLOAT strokeWidth,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_ BOOL *contains 
        '    ) CONST PURE;
        ''' <summary>
        ''' Checks to see whether the corresponding penned And widened geometry contains the
        ''' given point.
        ''' </summary>
        Function StrokeContainsPoint(<MarshalAs(UnmanagedType.Struct)> ByVal point As D2D1_POINT_2F,
                                     ByVal strokeWidth As Single,
                                     <[In](), MarshalAs(UnmanagedType.Interface)> ByVal strokeStyle As ID2D1StrokeStyle,
                                     <[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                                     ByVal flatteningTolerance As Single,
                                     <Out(), MarshalAs(UnmanagedType.Bool)> ByRef contains As Boolean) As HRESULT

        'STDMETHOD(FillContainsPoint)(
        '    D2D1_POINT_2F point,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_ BOOL *contains 
        '    ) CONST PURE;
        ''' <summary>
        ''' Test whether the given fill of this geometry would contain this point.
        ''' </summary>
        Function FillContainsPoint(<MarshalAs(UnmanagedType.Struct)> ByVal point As D2D1_POINT_2F,
                                   <[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                                   ByVal flatteningTolerance As Single,
                                   <Out(), MarshalAs(UnmanagedType.Bool)> ByRef contains As Boolean) As HRESULT


        'STDMETHOD(CompareWithGeometry)(
        '    _In_ ID2D1Geometry *inputGeometry,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *inputGeometryTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_ D2D1_GEOMETRY_RELATION *relation 
        '    ) CONST PURE;
        ''' <summary>
        ''' Compare how one geometry intersects Or contains another geometry.
        ''' </summary>
        Function CompareWithGeometry(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal inputGeometry As ID2D1Geometry,
                                     <[In](), MarshalAs(UnmanagedType.Struct)> ByRef inputGeometryTransform As D2D1_MATRIX_3X2_F,
                                     ByVal flatteningTolerance As Single,
                                     <Out()> ByRef point As D2D1_GEOMETRY_RELATION) As HRESULT


        'STDMETHOD(Simplify)(
        '    D2D1_GEOMETRY_SIMPLIFICATION_OPTION simplificationOption,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _In_ ID2D1SimplifiedGeometrySink *geometrySink 
        '    ) CONST PURE;
        ''' <summary>
        ''' Converts a geometry to a simplified geometry that has arcs And quadratic beziers
        ''' removed.
        ''' </summary>
        Function Simplify(ByVal simplificationOption As D2D1_GEOMETRY_SIMPLIFICATION_OPTION,
                          <[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                          ByVal flatteningTolerance As Single,
                          <[In](), MarshalAs(UnmanagedType.Interface)> ByVal geometrySink As ID2D1SimplifiedGeometrySink) As HRESULT


        'STDMETHOD(Tessellate)(
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _In_ ID2D1TessellationSink *tessellationSink 
        '    ) CONST PURE;
        ''' <summary>
        ''' Tessellates a geometry into triangles.
        ''' </summary>
        Function Tessellate(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                            ByVal flatteningTolerance As Single,
                            <[In](), MarshalAs(UnmanagedType.Interface)> ByVal tessellationSink As ID2D1TessellationSink) As HRESULT


        'STDMETHOD(CombineWithGeometry)(
        '    _In_ ID2D1Geometry *inputGeometry,
        '    D2D1_COMBINE_MODE combineMode,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *inputGeometryTransform,
        '    FLOAT flatteningTolerance,
        '    _In_ ID2D1SimplifiedGeometrySink *geometrySink 
        '    ) CONST PURE;
        ''' <summary>
        ''' Performs a combine operation between the two geometries to produce a resulting
        ''' geometry.
        ''' </summary>
        Function CombineWithGeometry(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal inputGeometry As ID2D1Geometry,
                                     ByVal combineMode As D2D1_COMBINE_MODE,
                                     <[In](), MarshalAs(UnmanagedType.Struct)> ByRef inputGeometryTransform As D2D1_MATRIX_3X2_F,
                                     ByVal flatteningTolerance As Single,
                                     <[In](), MarshalAs(UnmanagedType.Interface)> ByVal geometrySink As ID2D1SimplifiedGeometrySink) As HRESULT


        'STDMETHOD(Outline)(
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _In_ ID2D1SimplifiedGeometrySink *geometrySink 
        '    ) CONST PURE;
        ''' <summary>
        ''' Computes the outline of the geometry. The result Is written back into a
        ''' simplified geometry sink.
        ''' </summary>
        Function Outline(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                         ByVal flatteningTolerance As Single,
                         <[In](), MarshalAs(UnmanagedType.Interface)> ByVal geometrySink As ID2D1SimplifiedGeometrySink) As HRESULT


        'STDMETHOD(ComputeArea)(
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_ FLOAT *area 
        '    ) CONST PURE;
        ''' <summary>
        ''' Computes the area of the geometry.
        ''' </summary>
        Function ComputeArea(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                             ByVal flatteningTolerance As Single,
                             <Out()> ByRef area As Single) As HRESULT


        'STDMETHOD(ComputeLength)(
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_ FLOAT *length 
        '    ) CONST PURE;
        ''' <summary>
        ''' Computes the length of the geometry.
        ''' </summary>
        Function ComputeLength(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                               ByVal flatteningTolerance As Single,
                               <Out()> ByRef length As Single) As HRESULT


        'STDMETHOD(ComputePointAtLength)(
        '    FLOAT length,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _Out_opt_ D2D1_POINT_2F *point,
        '    _Out_opt_ D2D1_POINT_2F *unitTangentVector 
        '    ) CONST PURE;
        ''' <summary>
        ''' Computes the point And tangent a given distance along the path.
        ''' </summary>
        Function ComputePointAtLength(ByVal length As Single,
                                      <[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                                      ByVal flatteningTolerance As Single,
                                      <Out(), MarshalAs(UnmanagedType.Struct)> ByRef point As D2D1_POINT_2F,
                                      <Out(), MarshalAs(UnmanagedType.Struct)> ByRef unitTangentVector As D2D1_POINT_2F) As HRESULT

        'STDMETHOD(Widen)(
        '    FLOAT strokeWidth,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle,
        '    _In_opt_ Const D2D1_MATRIX_3X2_F *worldTransform,
        '    FLOAT flatteningTolerance,
        '    _In_ ID2D1SimplifiedGeometrySink *geometrySink 
        '    ) CONST PURE;
        ''' <summary>
        ''' Get the geometry And widen it as well as apply an optional pen style.
        ''' </summary>
        Function Widen(ByVal strokeWidth As Single,
                       <[In](), MarshalAs(UnmanagedType.Interface)> ByVal strokeStyle As ID2D1StrokeStyle,
                       <[In](), MarshalAs(UnmanagedType.Struct)> ByRef worldTransform As D2D1_MATRIX_3X2_F,
                       ByVal flatteningTolerance As Single,
                       <[In](), MarshalAs(UnmanagedType.Interface)> ByVal geometrySink As ID2D1SimplifiedGeometrySink) As HRESULT

    End Interface

End Namespace

