// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: manejoCanciones.proto

package mx.uv.manejoCanciones;

/**
 * Protobuf type {@code mnjCanciones.ListaCanciones}
 */
public final class ListaCanciones extends
    com.google.protobuf.GeneratedMessageV3 implements
    // @@protoc_insertion_point(message_implements:mnjCanciones.ListaCanciones)
    ListaCancionesOrBuilder {
private static final long serialVersionUID = 0L;
  // Use ListaCanciones.newBuilder() to construct.
  private ListaCanciones(com.google.protobuf.GeneratedMessageV3.Builder<?> builder) {
    super(builder);
  }
  private ListaCanciones() {
    canciones_ = java.util.Collections.emptyList();
  }

  @java.lang.Override
  @SuppressWarnings({"unused"})
  protected java.lang.Object newInstance(
      UnusedPrivateParameter unused) {
    return new ListaCanciones();
  }

  @java.lang.Override
  public final com.google.protobuf.UnknownFieldSet
  getUnknownFields() {
    return this.unknownFields;
  }
  private ListaCanciones(
      com.google.protobuf.CodedInputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    this();
    if (extensionRegistry == null) {
      throw new java.lang.NullPointerException();
    }
    int mutable_bitField0_ = 0;
    com.google.protobuf.UnknownFieldSet.Builder unknownFields =
        com.google.protobuf.UnknownFieldSet.newBuilder();
    try {
      boolean done = false;
      while (!done) {
        int tag = input.readTag();
        switch (tag) {
          case 0:
            done = true;
            break;
          case 10: {
            if (!((mutable_bitField0_ & 0x00000001) != 0)) {
              canciones_ = new java.util.ArrayList<mx.uv.manejoCanciones.Cancion>();
              mutable_bitField0_ |= 0x00000001;
            }
            canciones_.add(
                input.readMessage(mx.uv.manejoCanciones.Cancion.parser(), extensionRegistry));
            break;
          }
          default: {
            if (!parseUnknownField(
                input, unknownFields, extensionRegistry, tag)) {
              done = true;
            }
            break;
          }
        }
      }
    } catch (com.google.protobuf.InvalidProtocolBufferException e) {
      throw e.setUnfinishedMessage(this);
    } catch (java.io.IOException e) {
      throw new com.google.protobuf.InvalidProtocolBufferException(
          e).setUnfinishedMessage(this);
    } finally {
      if (((mutable_bitField0_ & 0x00000001) != 0)) {
        canciones_ = java.util.Collections.unmodifiableList(canciones_);
      }
      this.unknownFields = unknownFields.build();
      makeExtensionsImmutable();
    }
  }
  public static final com.google.protobuf.Descriptors.Descriptor
      getDescriptor() {
    return mx.uv.manejoCanciones.CancionesProto.internal_static_mnjCanciones_ListaCanciones_descriptor;
  }

  @java.lang.Override
  protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
      internalGetFieldAccessorTable() {
    return mx.uv.manejoCanciones.CancionesProto.internal_static_mnjCanciones_ListaCanciones_fieldAccessorTable
        .ensureFieldAccessorsInitialized(
            mx.uv.manejoCanciones.ListaCanciones.class, mx.uv.manejoCanciones.ListaCanciones.Builder.class);
  }

  public static final int CANCIONES_FIELD_NUMBER = 1;
  private java.util.List<mx.uv.manejoCanciones.Cancion> canciones_;
  /**
   * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
   */
  @java.lang.Override
  public java.util.List<mx.uv.manejoCanciones.Cancion> getCancionesList() {
    return canciones_;
  }
  /**
   * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
   */
  @java.lang.Override
  public java.util.List<? extends mx.uv.manejoCanciones.CancionOrBuilder> 
      getCancionesOrBuilderList() {
    return canciones_;
  }
  /**
   * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
   */
  @java.lang.Override
  public int getCancionesCount() {
    return canciones_.size();
  }
  /**
   * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
   */
  @java.lang.Override
  public mx.uv.manejoCanciones.Cancion getCanciones(int index) {
    return canciones_.get(index);
  }
  /**
   * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
   */
  @java.lang.Override
  public mx.uv.manejoCanciones.CancionOrBuilder getCancionesOrBuilder(
      int index) {
    return canciones_.get(index);
  }

  private byte memoizedIsInitialized = -1;
  @java.lang.Override
  public final boolean isInitialized() {
    byte isInitialized = memoizedIsInitialized;
    if (isInitialized == 1) return true;
    if (isInitialized == 0) return false;

    memoizedIsInitialized = 1;
    return true;
  }

  @java.lang.Override
  public void writeTo(com.google.protobuf.CodedOutputStream output)
                      throws java.io.IOException {
    for (int i = 0; i < canciones_.size(); i++) {
      output.writeMessage(1, canciones_.get(i));
    }
    unknownFields.writeTo(output);
  }

  @java.lang.Override
  public int getSerializedSize() {
    int size = memoizedSize;
    if (size != -1) return size;

    size = 0;
    for (int i = 0; i < canciones_.size(); i++) {
      size += com.google.protobuf.CodedOutputStream
        .computeMessageSize(1, canciones_.get(i));
    }
    size += unknownFields.getSerializedSize();
    memoizedSize = size;
    return size;
  }

  @java.lang.Override
  public boolean equals(final java.lang.Object obj) {
    if (obj == this) {
     return true;
    }
    if (!(obj instanceof mx.uv.manejoCanciones.ListaCanciones)) {
      return super.equals(obj);
    }
    mx.uv.manejoCanciones.ListaCanciones other = (mx.uv.manejoCanciones.ListaCanciones) obj;

    if (!getCancionesList()
        .equals(other.getCancionesList())) return false;
    if (!unknownFields.equals(other.unknownFields)) return false;
    return true;
  }

  @java.lang.Override
  public int hashCode() {
    if (memoizedHashCode != 0) {
      return memoizedHashCode;
    }
    int hash = 41;
    hash = (19 * hash) + getDescriptor().hashCode();
    if (getCancionesCount() > 0) {
      hash = (37 * hash) + CANCIONES_FIELD_NUMBER;
      hash = (53 * hash) + getCancionesList().hashCode();
    }
    hash = (29 * hash) + unknownFields.hashCode();
    memoizedHashCode = hash;
    return hash;
  }

  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      java.nio.ByteBuffer data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      java.nio.ByteBuffer data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      com.google.protobuf.ByteString data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      com.google.protobuf.ByteString data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(byte[] data)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      byte[] data,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws com.google.protobuf.InvalidProtocolBufferException {
    return PARSER.parseFrom(data, extensionRegistry);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseDelimitedFrom(java.io.InputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseDelimitedFrom(
      java.io.InputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseDelimitedWithIOException(PARSER, input, extensionRegistry);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      com.google.protobuf.CodedInputStream input)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input);
  }
  public static mx.uv.manejoCanciones.ListaCanciones parseFrom(
      com.google.protobuf.CodedInputStream input,
      com.google.protobuf.ExtensionRegistryLite extensionRegistry)
      throws java.io.IOException {
    return com.google.protobuf.GeneratedMessageV3
        .parseWithIOException(PARSER, input, extensionRegistry);
  }

  @java.lang.Override
  public Builder newBuilderForType() { return newBuilder(); }
  public static Builder newBuilder() {
    return DEFAULT_INSTANCE.toBuilder();
  }
  public static Builder newBuilder(mx.uv.manejoCanciones.ListaCanciones prototype) {
    return DEFAULT_INSTANCE.toBuilder().mergeFrom(prototype);
  }
  @java.lang.Override
  public Builder toBuilder() {
    return this == DEFAULT_INSTANCE
        ? new Builder() : new Builder().mergeFrom(this);
  }

  @java.lang.Override
  protected Builder newBuilderForType(
      com.google.protobuf.GeneratedMessageV3.BuilderParent parent) {
    Builder builder = new Builder(parent);
    return builder;
  }
  /**
   * Protobuf type {@code mnjCanciones.ListaCanciones}
   */
  public static final class Builder extends
      com.google.protobuf.GeneratedMessageV3.Builder<Builder> implements
      // @@protoc_insertion_point(builder_implements:mnjCanciones.ListaCanciones)
      mx.uv.manejoCanciones.ListaCancionesOrBuilder {
    public static final com.google.protobuf.Descriptors.Descriptor
        getDescriptor() {
      return mx.uv.manejoCanciones.CancionesProto.internal_static_mnjCanciones_ListaCanciones_descriptor;
    }

    @java.lang.Override
    protected com.google.protobuf.GeneratedMessageV3.FieldAccessorTable
        internalGetFieldAccessorTable() {
      return mx.uv.manejoCanciones.CancionesProto.internal_static_mnjCanciones_ListaCanciones_fieldAccessorTable
          .ensureFieldAccessorsInitialized(
              mx.uv.manejoCanciones.ListaCanciones.class, mx.uv.manejoCanciones.ListaCanciones.Builder.class);
    }

    // Construct using mx.uv.manejoCanciones.ListaCanciones.newBuilder()
    private Builder() {
      maybeForceBuilderInitialization();
    }

    private Builder(
        com.google.protobuf.GeneratedMessageV3.BuilderParent parent) {
      super(parent);
      maybeForceBuilderInitialization();
    }
    private void maybeForceBuilderInitialization() {
      if (com.google.protobuf.GeneratedMessageV3
              .alwaysUseFieldBuilders) {
        getCancionesFieldBuilder();
      }
    }
    @java.lang.Override
    public Builder clear() {
      super.clear();
      if (cancionesBuilder_ == null) {
        canciones_ = java.util.Collections.emptyList();
        bitField0_ = (bitField0_ & ~0x00000001);
      } else {
        cancionesBuilder_.clear();
      }
      return this;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.Descriptor
        getDescriptorForType() {
      return mx.uv.manejoCanciones.CancionesProto.internal_static_mnjCanciones_ListaCanciones_descriptor;
    }

    @java.lang.Override
    public mx.uv.manejoCanciones.ListaCanciones getDefaultInstanceForType() {
      return mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance();
    }

    @java.lang.Override
    public mx.uv.manejoCanciones.ListaCanciones build() {
      mx.uv.manejoCanciones.ListaCanciones result = buildPartial();
      if (!result.isInitialized()) {
        throw newUninitializedMessageException(result);
      }
      return result;
    }

    @java.lang.Override
    public mx.uv.manejoCanciones.ListaCanciones buildPartial() {
      mx.uv.manejoCanciones.ListaCanciones result = new mx.uv.manejoCanciones.ListaCanciones(this);
      int from_bitField0_ = bitField0_;
      if (cancionesBuilder_ == null) {
        if (((bitField0_ & 0x00000001) != 0)) {
          canciones_ = java.util.Collections.unmodifiableList(canciones_);
          bitField0_ = (bitField0_ & ~0x00000001);
        }
        result.canciones_ = canciones_;
      } else {
        result.canciones_ = cancionesBuilder_.build();
      }
      onBuilt();
      return result;
    }

    @java.lang.Override
    public Builder clone() {
      return super.clone();
    }
    @java.lang.Override
    public Builder setField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        java.lang.Object value) {
      return super.setField(field, value);
    }
    @java.lang.Override
    public Builder clearField(
        com.google.protobuf.Descriptors.FieldDescriptor field) {
      return super.clearField(field);
    }
    @java.lang.Override
    public Builder clearOneof(
        com.google.protobuf.Descriptors.OneofDescriptor oneof) {
      return super.clearOneof(oneof);
    }
    @java.lang.Override
    public Builder setRepeatedField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        int index, java.lang.Object value) {
      return super.setRepeatedField(field, index, value);
    }
    @java.lang.Override
    public Builder addRepeatedField(
        com.google.protobuf.Descriptors.FieldDescriptor field,
        java.lang.Object value) {
      return super.addRepeatedField(field, value);
    }
    @java.lang.Override
    public Builder mergeFrom(com.google.protobuf.Message other) {
      if (other instanceof mx.uv.manejoCanciones.ListaCanciones) {
        return mergeFrom((mx.uv.manejoCanciones.ListaCanciones)other);
      } else {
        super.mergeFrom(other);
        return this;
      }
    }

    public Builder mergeFrom(mx.uv.manejoCanciones.ListaCanciones other) {
      if (other == mx.uv.manejoCanciones.ListaCanciones.getDefaultInstance()) return this;
      if (cancionesBuilder_ == null) {
        if (!other.canciones_.isEmpty()) {
          if (canciones_.isEmpty()) {
            canciones_ = other.canciones_;
            bitField0_ = (bitField0_ & ~0x00000001);
          } else {
            ensureCancionesIsMutable();
            canciones_.addAll(other.canciones_);
          }
          onChanged();
        }
      } else {
        if (!other.canciones_.isEmpty()) {
          if (cancionesBuilder_.isEmpty()) {
            cancionesBuilder_.dispose();
            cancionesBuilder_ = null;
            canciones_ = other.canciones_;
            bitField0_ = (bitField0_ & ~0x00000001);
            cancionesBuilder_ = 
              com.google.protobuf.GeneratedMessageV3.alwaysUseFieldBuilders ?
                 getCancionesFieldBuilder() : null;
          } else {
            cancionesBuilder_.addAllMessages(other.canciones_);
          }
        }
      }
      this.mergeUnknownFields(other.unknownFields);
      onChanged();
      return this;
    }

    @java.lang.Override
    public final boolean isInitialized() {
      return true;
    }

    @java.lang.Override
    public Builder mergeFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws java.io.IOException {
      mx.uv.manejoCanciones.ListaCanciones parsedMessage = null;
      try {
        parsedMessage = PARSER.parsePartialFrom(input, extensionRegistry);
      } catch (com.google.protobuf.InvalidProtocolBufferException e) {
        parsedMessage = (mx.uv.manejoCanciones.ListaCanciones) e.getUnfinishedMessage();
        throw e.unwrapIOException();
      } finally {
        if (parsedMessage != null) {
          mergeFrom(parsedMessage);
        }
      }
      return this;
    }
    private int bitField0_;

    private java.util.List<mx.uv.manejoCanciones.Cancion> canciones_ =
      java.util.Collections.emptyList();
    private void ensureCancionesIsMutable() {
      if (!((bitField0_ & 0x00000001) != 0)) {
        canciones_ = new java.util.ArrayList<mx.uv.manejoCanciones.Cancion>(canciones_);
        bitField0_ |= 0x00000001;
       }
    }

    private com.google.protobuf.RepeatedFieldBuilderV3<
        mx.uv.manejoCanciones.Cancion, mx.uv.manejoCanciones.Cancion.Builder, mx.uv.manejoCanciones.CancionOrBuilder> cancionesBuilder_;

    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public java.util.List<mx.uv.manejoCanciones.Cancion> getCancionesList() {
      if (cancionesBuilder_ == null) {
        return java.util.Collections.unmodifiableList(canciones_);
      } else {
        return cancionesBuilder_.getMessageList();
      }
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public int getCancionesCount() {
      if (cancionesBuilder_ == null) {
        return canciones_.size();
      } else {
        return cancionesBuilder_.getCount();
      }
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public mx.uv.manejoCanciones.Cancion getCanciones(int index) {
      if (cancionesBuilder_ == null) {
        return canciones_.get(index);
      } else {
        return cancionesBuilder_.getMessage(index);
      }
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder setCanciones(
        int index, mx.uv.manejoCanciones.Cancion value) {
      if (cancionesBuilder_ == null) {
        if (value == null) {
          throw new NullPointerException();
        }
        ensureCancionesIsMutable();
        canciones_.set(index, value);
        onChanged();
      } else {
        cancionesBuilder_.setMessage(index, value);
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder setCanciones(
        int index, mx.uv.manejoCanciones.Cancion.Builder builderForValue) {
      if (cancionesBuilder_ == null) {
        ensureCancionesIsMutable();
        canciones_.set(index, builderForValue.build());
        onChanged();
      } else {
        cancionesBuilder_.setMessage(index, builderForValue.build());
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder addCanciones(mx.uv.manejoCanciones.Cancion value) {
      if (cancionesBuilder_ == null) {
        if (value == null) {
          throw new NullPointerException();
        }
        ensureCancionesIsMutable();
        canciones_.add(value);
        onChanged();
      } else {
        cancionesBuilder_.addMessage(value);
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder addCanciones(
        int index, mx.uv.manejoCanciones.Cancion value) {
      if (cancionesBuilder_ == null) {
        if (value == null) {
          throw new NullPointerException();
        }
        ensureCancionesIsMutable();
        canciones_.add(index, value);
        onChanged();
      } else {
        cancionesBuilder_.addMessage(index, value);
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder addCanciones(
        mx.uv.manejoCanciones.Cancion.Builder builderForValue) {
      if (cancionesBuilder_ == null) {
        ensureCancionesIsMutable();
        canciones_.add(builderForValue.build());
        onChanged();
      } else {
        cancionesBuilder_.addMessage(builderForValue.build());
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder addCanciones(
        int index, mx.uv.manejoCanciones.Cancion.Builder builderForValue) {
      if (cancionesBuilder_ == null) {
        ensureCancionesIsMutable();
        canciones_.add(index, builderForValue.build());
        onChanged();
      } else {
        cancionesBuilder_.addMessage(index, builderForValue.build());
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder addAllCanciones(
        java.lang.Iterable<? extends mx.uv.manejoCanciones.Cancion> values) {
      if (cancionesBuilder_ == null) {
        ensureCancionesIsMutable();
        com.google.protobuf.AbstractMessageLite.Builder.addAll(
            values, canciones_);
        onChanged();
      } else {
        cancionesBuilder_.addAllMessages(values);
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder clearCanciones() {
      if (cancionesBuilder_ == null) {
        canciones_ = java.util.Collections.emptyList();
        bitField0_ = (bitField0_ & ~0x00000001);
        onChanged();
      } else {
        cancionesBuilder_.clear();
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public Builder removeCanciones(int index) {
      if (cancionesBuilder_ == null) {
        ensureCancionesIsMutable();
        canciones_.remove(index);
        onChanged();
      } else {
        cancionesBuilder_.remove(index);
      }
      return this;
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public mx.uv.manejoCanciones.Cancion.Builder getCancionesBuilder(
        int index) {
      return getCancionesFieldBuilder().getBuilder(index);
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public mx.uv.manejoCanciones.CancionOrBuilder getCancionesOrBuilder(
        int index) {
      if (cancionesBuilder_ == null) {
        return canciones_.get(index);  } else {
        return cancionesBuilder_.getMessageOrBuilder(index);
      }
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public java.util.List<? extends mx.uv.manejoCanciones.CancionOrBuilder> 
         getCancionesOrBuilderList() {
      if (cancionesBuilder_ != null) {
        return cancionesBuilder_.getMessageOrBuilderList();
      } else {
        return java.util.Collections.unmodifiableList(canciones_);
      }
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public mx.uv.manejoCanciones.Cancion.Builder addCancionesBuilder() {
      return getCancionesFieldBuilder().addBuilder(
          mx.uv.manejoCanciones.Cancion.getDefaultInstance());
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public mx.uv.manejoCanciones.Cancion.Builder addCancionesBuilder(
        int index) {
      return getCancionesFieldBuilder().addBuilder(
          index, mx.uv.manejoCanciones.Cancion.getDefaultInstance());
    }
    /**
     * <code>repeated .mnjCanciones.Cancion canciones = 1;</code>
     */
    public java.util.List<mx.uv.manejoCanciones.Cancion.Builder> 
         getCancionesBuilderList() {
      return getCancionesFieldBuilder().getBuilderList();
    }
    private com.google.protobuf.RepeatedFieldBuilderV3<
        mx.uv.manejoCanciones.Cancion, mx.uv.manejoCanciones.Cancion.Builder, mx.uv.manejoCanciones.CancionOrBuilder> 
        getCancionesFieldBuilder() {
      if (cancionesBuilder_ == null) {
        cancionesBuilder_ = new com.google.protobuf.RepeatedFieldBuilderV3<
            mx.uv.manejoCanciones.Cancion, mx.uv.manejoCanciones.Cancion.Builder, mx.uv.manejoCanciones.CancionOrBuilder>(
                canciones_,
                ((bitField0_ & 0x00000001) != 0),
                getParentForChildren(),
                isClean());
        canciones_ = null;
      }
      return cancionesBuilder_;
    }
    @java.lang.Override
    public final Builder setUnknownFields(
        final com.google.protobuf.UnknownFieldSet unknownFields) {
      return super.setUnknownFields(unknownFields);
    }

    @java.lang.Override
    public final Builder mergeUnknownFields(
        final com.google.protobuf.UnknownFieldSet unknownFields) {
      return super.mergeUnknownFields(unknownFields);
    }


    // @@protoc_insertion_point(builder_scope:mnjCanciones.ListaCanciones)
  }

  // @@protoc_insertion_point(class_scope:mnjCanciones.ListaCanciones)
  private static final mx.uv.manejoCanciones.ListaCanciones DEFAULT_INSTANCE;
  static {
    DEFAULT_INSTANCE = new mx.uv.manejoCanciones.ListaCanciones();
  }

  public static mx.uv.manejoCanciones.ListaCanciones getDefaultInstance() {
    return DEFAULT_INSTANCE;
  }

  private static final com.google.protobuf.Parser<ListaCanciones>
      PARSER = new com.google.protobuf.AbstractParser<ListaCanciones>() {
    @java.lang.Override
    public ListaCanciones parsePartialFrom(
        com.google.protobuf.CodedInputStream input,
        com.google.protobuf.ExtensionRegistryLite extensionRegistry)
        throws com.google.protobuf.InvalidProtocolBufferException {
      return new ListaCanciones(input, extensionRegistry);
    }
  };

  public static com.google.protobuf.Parser<ListaCanciones> parser() {
    return PARSER;
  }

  @java.lang.Override
  public com.google.protobuf.Parser<ListaCanciones> getParserForType() {
    return PARSER;
  }

  @java.lang.Override
  public mx.uv.manejoCanciones.ListaCanciones getDefaultInstanceForType() {
    return DEFAULT_INSTANCE;
  }

}

